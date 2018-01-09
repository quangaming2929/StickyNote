using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sticky_Note
{
    static class SharedIems
    {
        public static string path = @"C:\Sticky Notes ReMake\";
        public static string SettingPath = path + @"Setting.dat";
        public static int openForm = 0;
        public static void ZeroForm()
        {
            if (openForm == 0)
            {
                CreateNote();
            }
        }
        public static void CreateNote()
        {
            Form1 newNote = new Form1(new Random().Next(1, 1000).ToString());
            newNote.Show();
            openForm++;
        }
    }
}
