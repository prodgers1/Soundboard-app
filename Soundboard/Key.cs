using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Soundboard
{
    public class Key
    {
        public string PathToSound { get; set; }
        public Keys KeyToPress { get; set; }

        public Key(string pathToSound, Keys key)
        {
            PathToSound = pathToSound;
            KeyToPress = key;
        }
    }
}
