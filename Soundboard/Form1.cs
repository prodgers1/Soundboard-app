using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Soundboard
{
    public partial class Form1 : Form
    {
        private WaveOutEvent output = new WaveOutEvent();
        private bool m_Playing = false;
        private List<Key> m_Keys = new List<Key>();
        private XDocument m_UserSettings;

        private string m_SettingsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Soundboard");
        
        public Form1()
        {
            InitializeComponent();
            output.PlaybackStopped += StopPlaying;
            Directory.CreateDirectory(m_SettingsPath);
            InitalizeSettings();
        }

        private void InitalizeSettings()
        {
            try
            {
                m_UserSettings = XDocument.Load(m_SettingsPath + @"\settings.xml");
            }
            catch (FileNotFoundException)
            {
                m_UserSettings = null;
            }

            if(m_UserSettings != null)
            {
                IEnumerable<XElement> settingElements = m_UserSettings.Element("Settings").Descendants().Where(d => d.Name == "Setting");
                foreach (XElement setting in settingElements)
                {
                    string keyToPress = setting.Element("Key").Value;
                    Keys keyEnum = (Keys)Enum.Parse(typeof(Keys), keyToPress, true);
                    string soundPath = setting.Element("SoundPath").Value;
                    Key key = new Key(soundPath, keyEnum);
                    BindHotkey(key);
                    m_Keys.Add(key);
                }
            }
        }

        private void BindHotkey(Key addedKey)
        {
            KeyboardHook hook = new KeyboardHook();
            hook.KeyPressed +=
                new EventHandler<KeyPressedEventArgs>(hook_KeyPressed);
            hook.RegisterHotKey(Soundboard.ModifierKeys.Alt, addedKey.KeyToPress);
        }

        private void SaveToApplicationData()
        {
            m_UserSettings.Save(m_SettingsPath + @"\settings.xml");
        }

        private void AppendXml(Key addedKey)
        {
            XElement settingsElement = m_UserSettings.Element("Settings");
            XElement existingKey = settingsElement.Descendants()
                .Where(d => d.Name == "Setting").Descendants()
                .Where(d => d.Name == "Key")
                .Where(k => k.Value == addedKey.KeyToPress.ToString()).SingleOrDefault();


            if (existingKey == null)
            {
                XElement setting = new XElement("Setting");
                XElement keyElement = new XElement("Key", addedKey.KeyToPress.ToString());
                XElement soundPathElement = new XElement("SoundPath", addedKey.PathToSound);
                setting.Add(keyElement);
                setting.Add(soundPathElement);
                settingsElement.Add(setting);
            }
            else
            {
                XElement setting = existingKey.Parent;
                setting.Element("SoundPath").Value = addedKey.PathToSound;
            }
        }

        private void InitializeXml(Key addedKey)
        {
            m_UserSettings = new XDocument();
            XElement settings = new XElement("Settings");
            XElement setting = new XElement("Setting");
            XElement keyElement = new XElement("Key", addedKey.KeyToPress.ToString());
            XElement soundPathElement = new XElement("SoundPath", addedKey.PathToSound);
            setting.Add(keyElement);
            setting.Add(soundPathElement);
            settings.Add(setting);
            m_UserSettings.Add(settings);
        }

        private void StopPlaying(object sender, EventArgs e)
        {
            m_Playing = false;
            output.Stop();
        }

        void hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            Key pressedKey = m_Keys.Where(k => k.KeyToPress == e.Key).SingleOrDefault();

            if (!m_Playing)
            {
                m_Playing = true;
                var audioFile = new AudioFileReader($@"{pressedKey.PathToSound}");
                output.Init(audioFile);
                output.Play();
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string keyToPress = keyToPressTextBox.Text;
            Keys key = (Keys)Enum.Parse(typeof(Keys), keyToPress, true);
            Key newKey = new Key(soundPathText.Text, key);
            if (m_Keys.Any(k => k.KeyToPress == key))
            {
                Key keyToRemove = m_Keys.Where(k => k.KeyToPress == key).Single();
                m_Keys.Remove(keyToRemove);
                m_Keys.Add(newKey);

            }
            else
                m_Keys.Add(newKey);


            BindHotkey(newKey);

            if (m_UserSettings == null)
            {
                InitializeXml(newKey);
            }
            else
            {
                AppendXml(newKey);
            }

            SaveToApplicationData();

            soundPathText.Text = "";
            keyToPressTextBox.Text = "";
        }

        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                soundPathText.Text = openFileDialog1.FileName;
            }
        }

        private void rebindButton_Click(object sender, EventArgs e)
        {
            m_Keys.Clear();
            InitalizeSettings();
        }
    }
    public sealed class KeyboardHook : IDisposable
    {
        // Registers a hot key with Windows.
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);
        // Unregisters the hot key with Windows.
        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        public string PathToSounds { get; set; }

        /// <summary>
        /// Represents the window that is used internally to get the messages.
        /// </summary>
        private class Window : NativeWindow, IDisposable
        {
            private static int WM_HOTKEY = 0x0312;

            public Window()
            {
                // create the handle for the window.
                this.CreateHandle(new CreateParams());
            }

            /// <summary>
            /// Overridden to get the notifications.
            /// </summary>
            /// <param name="m"></param>
            protected override void WndProc(ref Message m)
            {
                base.WndProc(ref m);

                // check if we got a hot key pressed.
                if (m.Msg == WM_HOTKEY)
                {
                    // get the keys.
                    Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);
                    ModifierKeys modifier = (ModifierKeys)((int)m.LParam & 0xFFFF);

                    // invoke the event to notify the parent.
                    if (KeyPressed != null)
                    {
                        var args = new KeyPressedEventArgs(modifier, key);
                        KeyPressed(this,args );

                    }
                }
            }

            public event EventHandler<KeyPressedEventArgs> KeyPressed;

            #region IDisposable Members

            public void Dispose()
            {
                this.DestroyHandle();
            }

            #endregion
        }

        private Window _window = new Window();
        private int _currentId;

        public KeyboardHook()
        {
            // register the event of the inner native window.
            _window.KeyPressed += delegate (object sender, KeyPressedEventArgs args)
            {
                if (KeyPressed != null)
                {
                    args.SoundToPlay = PathToSounds;
                    KeyPressed(this, args);

                }
            };
        }

        /// <summary>
        /// Registers a hot key in the system.
        /// </summary>
        /// <param name="modifier">The modifiers that are associated with the hot key.</param>
        /// <param name="key">The key itself that is associated with the hot key.</param>
        public void RegisterHotKey(ModifierKeys modifier, Keys key)
        {
            // increment the counter.
            _currentId = _currentId + 1;

            // register the hot key.
            if (!RegisterHotKey(_window.Handle, _currentId, (uint)modifier, (uint)key))
            {
                UnregisterHotKey(_window.Handle, _currentId);
                RegisterHotKey(_window.Handle, _currentId, (uint)modifier, (uint)key);
            }
        }

        /// <summary>
        /// A hot key has been pressed.
        /// </summary>
        public event EventHandler<KeyPressedEventArgs> KeyPressed;

        #region IDisposable Members

        public void Dispose()
        {
            // unregister all the registered hot keys.
            for (int i = _currentId; i > 0; i--)
            {
                UnregisterHotKey(_window.Handle, i);
            }

            // dispose the inner native window.
            _window.Dispose();
        }

        #endregion
    }

    /// <summary>
    /// Event Args for the event that is fired after the hot key has been pressed.
    /// </summary>
    public class KeyPressedEventArgs : EventArgs
    {
        private ModifierKeys _modifier;
        private Keys _key;
        public string SoundToPlay { get; set; }

        internal KeyPressedEventArgs(ModifierKeys modifier, Keys key)
        {
            _modifier = modifier;
            _key = key;
        }

        public ModifierKeys Modifier
        {
            get { return _modifier; }
        }

        public Keys Key
        {
            get { return _key; }
        }
    }

    /// <summary>
    /// The enumeration of possible modifiers.
    /// </summary>
    [Flags]
    public enum ModifierKeys
    {
        Alt = 1,
        Control = 2,
        Shift = 4,
        Win = 8
    }

}
