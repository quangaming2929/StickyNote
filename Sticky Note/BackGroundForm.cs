using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Sticky_Note
{
    public partial class BackGroundForm : Form
    {
        public BackGroundForm()
        {
            InitializeComponent();
            this.Visible = false;
            ShowInTaskbar = false;
            Opacity = 0;
            MakeDir();
        }

        private void MakeDir()
        {
            Directory.CreateDirectory(path);
        }

        string path = @"C:\Stick Notes ReMake";

        private void BackGroundForm_Load(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            SharedIems.openForm++;
        }
        
    }
}
