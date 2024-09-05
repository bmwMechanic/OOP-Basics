using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceDemoApp
{
    public class Parent     //BASE class or SUPER class
    {
        public static int Zahl = 5;

        public int PubA;
        private int PriA;   //private will be hidden from the Child Class. BUT It will be copied to the Child memory, but its use is prohibited by Parent class
        protected int ProA; //ProA is'public' to Child class, but private to all other classes!

        static Parent() {} //just fun fun purposes
        public Parent() {/*PubA = 1;*/} // What if I comment paramLESS Constr. of Parent class? problem: Child class constr. first touches param constr. Parent class then goes to paramLESS constr. which here is no longer available.  So the !!PARAMLESS!! child class constr. needs to call itselft by ':base(0,0,0)'
        public Parent(int PriA, int ProA, int PubA ) //:this()
        {
            this.PriA = PriA; this.ProA = ProA; this.PubA = PubA;   //Parent Constr. takes care of initializing Parent fields and properties, later child class initializes Child class fields and properties
        }
        public Parent(Parent previousParent) : this(previousParent.PriA, previousParent.ProA, previousParent.PubA) { }    //ALTERNATE copy constructor:     https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/how-to-write-a-copy-constructor
        



    }

}
