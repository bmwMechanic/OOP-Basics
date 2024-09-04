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
        private int PriA;   //private will be hidden from the Child Class. It will be copied to the Child memory, but its use is prohibited by Parent class
        protected int ProA; //ProA is'public' to Child class, but private to all other classes!

        static Parent() {}
        public Parent() {/*PubA = 1;*/}
        public Parent(int PriA, int ProA, int PubA ) :this()
        {
            this.PriA = PriA; this.ProA = ProA; this.PubA = PubA;
        }
        public Parent(Parent previousParent) : this(previousParent.PriA, previousParent.ProA, previousParent.PubA) { }    //ALTERNATE copy constructor:     https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/how-to-write-a-copy-constructor
        



    }

}
