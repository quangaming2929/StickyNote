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
#region This isnt my code (QuangamingVn) I copy it from Stack Overflow :(
        //This isnt my code (QuangamingVn) I copy it from Stack Overflow :(
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();
#endregion

        //I want the Form to be pre-Tagged for the Location to work properly so to add object tag will
        //make it to work
        public Form1(object tag)
        {
            Tag = tag;
            InitializeComponent();
            LoadCustomComponent();
            WriteLocation();
        }

        //For controls I want to add by code
        void LoadCustomComponent()
        {
            //Defalut Location
            Location = new Point(100, 100);

            //Menu Strip
            fakeControl.BackColor = Color.Indigo;

            //Item On Menu Strip
            xToolStripMenuItem.Alignment = ToolStripItemAlignment.Right;
            xToolStripMenuItem.ForeColor = Color.Orange;
            toolStripMenuItem1.ForeColor = Color.Orange;
            //Timer
            timer1.Start();
            //File
            if (!Directory.Exists(SharedIems.path + @"fileID" + Tag + ".dat"))
            {
                FileStream fs = new FileStream(SharedIems.path + @"fileID" + Tag + ".dat", FileMode.Create);
                fs.Close();
            }
        }
        
        //This event make the MenuStrip to behave like a control bar, cause this form already disable form
        //border
        private void fakeControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
            WriteLocation();
        }
        //This method used for Write the Location of the form to a file, FormID = Tag that pre-created. 
        //To make other time we open the program, the program will read the information given in those file
        //and the tag will re-tag into new form
        private void WriteLocation()
        {
            FileStream saveFile = new FileStream(SharedIems.path + @"fileID" + Tag + ".dat", FileMode.Open);
            saveFile.Position = 0;
            string save = "Location: " + Location.X.ToString() + " , " + Location.Y.ToString() + "\r\n";
            byte[] saveByte = Encoding.Default.GetBytes(save);
            saveFile.Write(saveByte, 0, saveByte.Length);
            saveFile.Close();

            WriteSize();
        }
        private void WriteSize()
        {
            FileStream saveFile = new FileStream(SharedIems.path + @"fileID" + Tag + ".dat", FileMode.Open);
            saveFile.Position = saveFile.Length;
            string save = "Size: " + Size.Width.ToString() + " , " + Size.Height.ToString() + "\r\n";
            byte[] saveByte = Encoding.Default.GetBytes(save);
            saveFile.Write(saveByte, 0, saveByte.Length);
            saveFile.Close();
        }
        //To close/delete the note
        private void xToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Do you want to delete this note?", "Delete Note", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Close();
                File.Delete(SharedIems.path + @"fileID" + Tag + ".dat");
                File.Delete(SharedIems.path + @"fileID" + Tag + ".txt");
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
            //Future Use for Real-Time Saving
            byte[] realTimeSave = Encoding.Default.GetBytes(txbInput.Text);
            FileStream fs = new FileStream(SharedIems.path + @"fileID" + Tag + ".txt", FileMode.Create);
            fs.Write(realTimeSave, 0, realTimeSave.Length);
            fs.Close();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            MessageBox.Show("HIII");
        }

        #region Resize On stack overflow
        // Again, I didnt code this
        protected override void WndProc(ref Message m)
        {
            const int RESIZE_HANDLE_SIZE = 10;

            switch (m.Msg)
            {
                case 0x0084/*NCHITTEST*/ :
                    base.WndProc(ref m);

                    if ((int)m.Result == 0x01/*HTCLIENT*/)
                    {
                        Point screenPoint = new Point(m.LParam.ToInt32());
                        Point clientPoint = this.PointToClient(screenPoint);
                        if (clientPoint.Y <= RESIZE_HANDLE_SIZE)
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)13/*HTTOPLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)12/*HTTOP*/ ;
                            else
                                m.Result = (IntPtr)14/*HTTOPRIGHT*/ ;
                        }
                        else if (clientPoint.Y <= (Size.Height - RESIZE_HANDLE_SIZE))
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)10/*HTLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)2/*HTCAPTION*/ ;
                            else
                                m.Result = (IntPtr)11/*HTRIGHT*/ ;
                        }
                        else
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)16/*HTBOTTOMLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)15/*HTBOTTOM*/ ;
                            else
                                m.Result = (IntPtr)17/*HTBOTTOMRIGHT*/ ;
                        }
                    }
                    return;
            }
            base.WndProc(ref m);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style |= 0x20000; // <--- use 0x20000
                return cp;
            }
        }
        //
        #endregion

        //This varible is used for if the form is load more than 3 sec the t will return true
        bool t = false;
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if(t)
                MessageBox.Show("LOL Size changed bro");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            t = true;
            timer1.Stop();
        }
    }
}
