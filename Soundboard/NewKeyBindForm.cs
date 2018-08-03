using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Soundboard
{
    public partial class NewKeyBindForm : Form
    {
        public List<Key> Keys;
        private TypeConverter m_Converter = new TypeConverter();
        public Key addedKey;
        public NewKeyBindForm()
        {
            InitializeComponent();
        }

        public NewKeyBindForm(List<Key> keys)
            :this()
        {
            Keys = keys;
        }

        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                soundPathText.Text = openFileDialog1.FileName;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string keyToPress = keyToPressTextBox.Text;
            Keys key = (Keys)Enum.Parse(typeof(Keys), keyToPress, true);
            if (!Keys.Any(k => k.KeyToPress == key))
            {
                Key newKey = new Key(soundPathText.Text, key);
                Keys.Add(newKey);
                DialogResult = DialogResult.OK;

                addedKey = newKey;                


            }
            this.Close();
        }
    }
}
