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

        public Form1()
        {
            InitializeComponent();
            LoadCustomComponent();


        }
        void LoadCustomComponent()
        {
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
        }

        private void xToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
            SharedIems.openForm--;
            SharedIems.ZeroForm();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form1 newNote = new Form1();
            newNote.Show();
            SharedIems.openForm++;
        }

        private void txbInput_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
