using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Bd_Footbollers
{
    public partial class Form_FotoPlayer : Form
    {
        public Form_FotoPlayer(String str)
        {
            InitializeComponent();
            if (File.Exists(str))
                pictureBox1.Load(str);
            
            
        }
    }
}
