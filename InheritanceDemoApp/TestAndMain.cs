using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceDemoApp
{
    public class TestAndMain
    {
        static void Main(string[] args)
        {
            //While binding: Access Modifiers(+,-,#,...) cannot be changed!

            Parent p = new Child();
            //Console.WriteLine(p.N); // is always static. so if Parent class variable --> Parent class Member!
            //p.Action();

            Child c = new Grandchild(); //Console.WriteLine(c.N); //static binding
            Console.WriteLine();
            //Console.WriteLine(((Child)p).N);    //now using Child Parameter through explicit casting!

            p.M = 5; c.Action();        // Grandchild method virt<--overr<--overr method, M is 0 b/c overridden by Grandchild class property M which was never set :)
            p.Action();                 // Child Method, M is 5!
            
            /** Field Members are always binded statically (*new*) now what about Properties haha? Let's try out! 
             *  OMG --> PROPERTIES can be binded DYNAMICALLY! 
             * 
             * here Action method is virtual<--override<--override 
             * 
             * If lines 23+24 are binded statically, none<--new<--new then M Property value of Parent varibale p class is 0 b/c it was never set!
             * 
             *  If Dynamically: virt<--override sealed<-- override/new/new virtual (it doesn't matter, never accessed b/c of sealed)
             *  c.Action is calling Grandchild Action and M value is 0; M is sealed @Child class level!
             *  p.Action is calling Child Method and M value is 5! :)
             *  
             *  If Dynamically: virt<--override<--new. c Grandchild obj M value is 0; p Child object M value is 5.
             */

            /** Usage of SEALED in classes, Methods and Properties      
             */

            /**  CASTING Recap + Dynamic Binding!      . 
             * IF c = (Child)p;  followed by this: c.Action();p.Action();
             *  Both Output Child Method! if virtual<--override<--override is used
             *  
             *  whereas here: p = c;        c.Action(); p.Action();
             *  Output:  Grandchild       if virtual<--override<--override is used
             */

        }

        /**   basically FIELDS cannot be Dynamically binded! only public new <T>; is possible: new means hidden ...BUT...
         *  ADVICE: Do NOT use same Variable names in inhertited classes!
         *  ...BUT... keyword SEALED:
         */

        public class Parent
        {
            public int N=1;
            public virtual int M { get; set; }
            public virtual void Action()
            {
                Console.WriteLine("Parent Method, M value: " + this.M);

            }
        }

        public class Child : Parent
        {
            public new int N=2;
            public override int M { get; set; }

            public override void Action()
            {
                Console.WriteLine("Child Method, M value: " + this.M);

            }
        }

        public sealed class Grandchild : Child
        {
            public new int N = 3;
            public new int M { get; set; }


            public override void Action()
            {
                Console.WriteLine("Grandchild Method, M value: " + this.M);
            }
        }
        /*      No One can inherit from  Grandchild if it is 
        public class GrandGrandchild : Grandchild
        {
            public override void Action()
            {
                Console.WriteLine("GrandGrandChild Method");
            }
        }
        */
    }
}
