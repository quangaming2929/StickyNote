using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sticky_Note
{
    static class SharedIems
    {
        public static int openForm = 0;
        public static void ZeroForm()
        {
            if (openForm == 0)
            {
                Form1 f = new Form1();
                f.Show();
                openForm++;
            }
        }
    }
}
