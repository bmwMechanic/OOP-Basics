using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsTwo
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AccountForm());

            /**until now: Encapsulation: classes, objects, and everything according to it
             * next Chapter: INHERITANCE + Abstraction; later on Polymorphism
             * 1. Introduction to Inheritance
             * 2. Constructors and Inheritance
             * 3. Type Casting of Reference Types
             * 4. Static and Dynamic Binding
             * 5. Abstract classes
             */
        }
    }
}
