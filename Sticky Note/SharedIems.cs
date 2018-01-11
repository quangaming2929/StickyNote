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
        //This field use for check how many notes are open!, cause when the last note is close, we cant
        //create a new one using those given button on form 1. So we need to check that under the ZeroForm()
        //method
        public static int openForm = 0;

        //This method use for check if this is a final notes has been deleted, if yes a new note will be create
        public static void ZeroForm()
        {
            if (openForm == 0)
            {
                CreateNote();
            }
        }
        //Used for create note
        public static void CreateNote()
        {
            Form1 newNote = new Form1(new Random().Next(1, 1000).ToString());
            newNote.Show();
            openForm++;
        }
    }
}
