using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceDemoApp
{
    public class Abstract{}
    public class AB { public static void Method(ref int a) { a = 10; } }   //nothing speacial... yet...
    public abstract class ABC : AB { public static new void Method(ref int a) { a = 5; } }  //First Methods of 1st Gen. shall not be abstract!
    public abstract class ABCD : ABC { public abstract new void Method(ref int a); }  //2nd Methods in 2nd Gen. SHALL BE abstract with no body. IT#S THE ***SAME*** METHOD as in ABC!!!!
    public class ABCDE : ABCD { public override void Method(ref int a) { a = 44; } }
    /** AB = Parent; all public
     * ABC = Child; all public, Method is *NOT ABSTRACT* but static b/c abstract Class and is 'new' b/c Method exists in Parent abstr. class
     * ABCD = GrandChild; all public, 'new' void Method but NOW ABSTRACT, b/c not static; override not possible at any time
     *      = Mehod but MUST NOT have its own body! It rather ends with Semicolon;
     */

}
