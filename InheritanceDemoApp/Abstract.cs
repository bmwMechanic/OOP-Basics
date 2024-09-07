using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceDemoApp
{
    public class Abstract{
        static void Main(string[] args)
        {
            //   Abstraction
            int a = 0;        
            if (args[0] == "c") { a = 1; } else { a = 2; }  //click on project, Debug --> c
            //AB ab = new AB(); ab.Method(ref a);   //let's try to make AB static...
            AB.Do(ref a);   //a = 10
            ABC.Do(ref a);  //Calling this non-abstract method in abstract class; a=5
            //ABCD.Method(ref a); //Abstract is there for Inheritance and Copy Member in new inherited Classes Purposes!
            Console.WriteLine(a); //a=5;
            //*/
            Console.ReadKey();
        }
    }
    public class AB { public static void Do(ref int a) { a = 10; } }   //CONCRETE Class --> can be instantiated!
    public abstract class ABC : AB { public ABC() { } public static new void Do(ref int a) { a = 5; } }  //First Methods of 1st Gen. shall not be abstract!

    //From here about Abstract class and abstract Method! Method must be written in concrete Child classes
    public abstract class ABCD : ABC { public /*abstract*/ ABCD() { } public abstract void Action(ref int a); }  //2nd Methods in 2nd Gen. SHALL BE abstract with no body. IT#S THE ***SAME*** METHOD as in ABC!!!!
    public abstract class ABCDE : ABCD { public ABCDE() { } public override void Action(ref int a) { a = 44; } }   // abstract method from previous Generation can be overridden and used in next concrete Gen. But here there is a body needed, even if empty.
    public abstract class ABCDEF : ABCDE { public ABCDEF() { } public override void Action(ref int a) { a = 9000; } }
    public class ABCDEFG : ABCDEF {
        public ABCDEFG() { }
        public override void Action(ref int a) { a = 123; } }
    
    /** AB = Parent; all public
     * ABC = Child; all public, Method is *NOT ABSTRACT* but static b/c abstract Class and is 'new' b/c Method exists in Parent abstr. class
     * ABCD = GrandChild; all public, 'new' void Method but NOW ABSTRACT, b/c not static; override not possible at any time. here: b/c no Method to override available
     *      = Mehod but MUST NOT have its own body! It rather ends with Semicolon; Whereas overrider-methods must have a body, even if ABSTRACT
     */

    /** Abstraction MISCONSEPTIONS
     * 1. Abstract Class can have a Constructor independently of inheritance! public ClassName(){}  <--- like this. no abstract before ClassName!
     * 2. Child class constr. can call a Parent class constructor
     * 3. why? b/c I can say. Figure, tell me what type of object you want, if(condition) create circle , else create square. take a look at AbstractFigure.cs
     */

}
