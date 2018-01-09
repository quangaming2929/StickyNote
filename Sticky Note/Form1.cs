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
using System.Runtime.InteropServices;


namespace Sticky_Note
{
    public partial class Form1 : Form
    {
        //
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();
        //

        public Form1(object tag)
        {
            Tag = tag;
            InitializeComponent();
            LoadCustomComponent();
            WriteLocation();

        }
        void LoadCustomComponent()
        {
            //Defalut Location
            Location = new Point(100, 100);
            //Menu Strip
            fakeControl.BackColor = Color.Indigo;
            
            //Item On Menu Strip
            xToolStripMenuItem.Alignment = ToolStripItemAlignment.Right;
            xToolStripMenuItem.ForeColor = Color.Orange;
        }
        
        private void fakeControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
            WriteLocation();
        }
        private void WriteLocation()
        {
            if (Tag == null)
                MessageBox.Show("Cant NULL!!!");
            FileStream saveFile = new FileStream(SharedIems.path + @"fileID" + Tag + ".dat", FileMode.Create);
            saveFile.Position = 0;
            string save = "Location: " + Location.X.ToString() + " , " + Location.Y.ToString();
            byte[] saveByte = Encoding.Default.GetBytes(save);
            saveFile.Write(saveByte, 0, saveByte.Length);

            saveFile.Close();
        }
        private void xToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Do you want to delete this note?", "Delete Note", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Close();
                SharedIems.openForm--;
                SharedIems.ZeroForm();
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SharedIems.CreateNote();
        }

        private void txbInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            MessageBox.Show("HIII");
        }

    }
}
