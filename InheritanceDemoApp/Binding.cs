using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceDemoApp
{
// wait a minute! There is +,-,# but also protected internal and private protected

    public class Binding
    {
        /** STATIC and DYNAMIC Binding(inheritance);  key words: 'new', 'virtual', 'override', 'sealed', 'abstract'(if abstr. whole class must be abstract)
         * private new is possible! private virtual/override IS NOT possible! Nor is private abstract class allowed!
         */
        /** if multiple 
         *               static void Main(string[] args) { }
         *                                                    exist
         * press ALT+ENTER to access Project Properties. Select Startup-Project (that Main will then be called!)
         */
    }
    

    public class CParent
    {
        public void Foo() { }   //a method of Parent class...
        //public void Foo(int a) { }  //Method OverLOADING
        public virtual int Footoo() { return 1; }
        public int FootooStatBind() { return 10; }  //this cannot be commented out; pp needs to have a valid CParent Method!
    }

    public class CChild : CParent //... is overloaded in Child class!
    {
        public new void Foo() { }//what about ´the same function again in Child class? // USE THE *NEW* KEY if HIDING was INTENDED :) Shadownig/Hiding 
        public void Foo(int a) { }  //also Method-OverLoading!! 

        public override int Footoo() { return 2; }   //virtual first, then override OR new. in next gen classes in each per function 1 *override* OR *new* possible. override overrides virual, override OR ABSTRACT!
        public new int FootooStatBind() { return 20; }

    }

    public class CGrandChild : CChild 
    {
        public override int Footoo() { return 3; }  //so yes , like stated above (l.31) here: override OR new is possible!
        public new void Foo() { }   //3rd Gen, so 2nd time *new* for same method is possible! 
        public new int FootooStatBind() { return 30; }

    }

    /** Difference: Shadowing(Hiding) and Overriding
     * if virt. is int return, override OR new must be as well in next Gen. Override methods only differ in Method BODIES!
     * 
     */
}
