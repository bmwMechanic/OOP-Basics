using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsTwo
{
    public partial class AccountForm : Form
    {

        /**NOW:
         *  a.Balance = 1000;     -->   SET-Method is called
         *  decimal bal = a.Balance; -> GET-Method is called
         */
        public AccountForm()
        {
            InitializeComponent();
        }

        Account a; //Declaration needed b/c I need global variable a that references to Obj.

        private void btnCreate_Click(object sender, EventArgs e)
        {
            a = new Account();      //one constructor
   // b/c ID autoincr        Account a1 = new Account(654321,"a1Name",100000);   //one param. constructor w/3 params + this()
   // b/c ID autoincr        Account a2 = new Account(a1); //one this(a1), one this(params), one this()  //Fail at new Account(a), b/c there's no Name initialized, b/c created by DEFAULT CONSTRUCTOR method! copy the correct object dude...
            /* b/c constr. are called after obj is created, in lines above there will be 3 objects, but 6 constructors will be called! */
            //a1 + object ref by a1, a2 + obj ref by a2 are destroyed after exiting this method ;) added for break point debugging right there
        }

        private void btnSet_Click(object sender, EventArgs e)   //links von  istGleich ==> SET; var rechts vom istGleich ==> GET!
        {
            //a.ID = int.Parse(txtID.Text);
            a.Name = txtName.Text;
            //a.Balance = int.Parse(txtBalance.Text);   balance is read-only for class-outsiders! (private set for public Balance, remember? ;) )
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            txtID.Text = a.ID.ToString();
            txtName.Text = a.Name;
            txtBalance.Text = a.Balance.ToString();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtName.Text = "";
            txtBalance.Text = "";
        }

        private void btnDestroy_Click(object sender, EventArgs e)
        {
            a = null;
        }

        private void btnGC_Click(object sender, EventArgs e)
        {
            GC.Collect();   //this affects cpu pretty much b/c it's another thread extra
            // our code needs one thread
        }

        private void btnTemp_Click(object sender, EventArgs e)
        {
            Account a1 = new Account();
            a = a1;
            //if I create normal object, enter values, create temp, clear and get --> no values :) + 1st obj. ready for GC.Collect();
            // b/c "old" object referenced by "old" a get gc, a references to new Obj w/ no values 
        }

        private void btnGetGeneration_Click(object sender, EventArgs e)
        {
            /*why generation?-->Threads!
             * so b/c of GC! heap is equally divided into 3 parts by CLR
             * HEAP: Gen0: objects creation; when full->GC activated; 
             * Gen1: existing obj w/ ref will be then stored here. At some point of time G0 AND G1 will be full:
             *       GC activated, those with ref will be promoted to G2! G1 is empty, G0 is not empty
             * Gen2: only objects, that last longest in memory.
             * why cool: Intelligent Automatic Garbage Collection
             */
            System.Windows.Forms.MessageBox.Show(GC.GetGeneration(a).ToString()/*+"\n"+GC.GetGeneration(a).GetType()*/);    //GC.GetGen returns INT32
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            a.Deposit(decimal.Parse(txtAmount.Text));
            btnGet_Click(sender, e); //my own idea yeah :) it works fine! the function just needs a sender object and an e EventArgs as parameters
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            a.Withdraw(decimal.Parse(txtAmount.Text));
            btnGet_Click(sender, e);
        }

        private void btnSetMB_Click(object sender, EventArgs e)
        {
            Account.MinBalance = decimal.Parse(txtMB.Text);
        }

        private void btnGetMB_Click(object sender, EventArgs e)
        {
            txtMB.Text = Account.MinBalance.ToString();
        }
    }
}
