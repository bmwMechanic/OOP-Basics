using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsTwo
{
    public class Account
    {
        public int ID;
        public string Name;
        public int Balance;
        
        public Account()
        {
            System.Windows.Forms.MessageBox.Show("object created.");
        }

        ~Account()
        {
            System.Windows.Forms.MessageBox.Show("object destructed.");
        }
    }
}
