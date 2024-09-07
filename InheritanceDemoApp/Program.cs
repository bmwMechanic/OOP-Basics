using System.Threading.Channels;

namespace InheritanceDemoApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /** displayed ALL IN ONE
             * Parent<--Child<--GrandChild;
             * 
             * none<--new<--new
             * none<--new virtual<-- new OR override
             * new virtual: new in respect to Parent, virtual in respect to next inheriting class here GrandChild
             * 
             * 
             * 
             * virtual<--new<--new
             * virtual<--new virtual<--new OR override: Child new: b/c of new, we can have new in GrandChild, b/c of virtual we can have override in GrandChild!
             * virtual<--override<--new OR override.
             * virtual<--override sealed<--new ONLY (b/c override was sealed!)
             * 
             */

            /** Summary
             * using ref var of type CParent - Child class method is only exectuted when
             * 1. the actual object is of type CChild! so CParent p = new CChild() and
             * 2. Child class method OVERRIDES virtual method of CParent Class!
             */

            CParent pp = new CChild();
            /** about *NEW*
             * new method is only accessed by class object itself with it's own class pointer variable!
             * The new keyword hides the parent class method when accessed through a child class reference.
             * When you call the method on a parent class reference, the parent class method is executed,
             * b/c then the CChild class method is hidden? YES
             * So *new* is hiding based on CParent or CChild TYPE Variable
             */

            //*STATIC* Binding
            int bb = pp.FootooStatBind();
            /**   COMPILE TIME - decisions based upon DataType!
             *  sooo.. CPARENT Pointer p leads to CPARENT Functionality for Object CChild!
             *  CParent Functionality? well then: FootooStatBind = 10
             *  in STATIC BINDING the pointer Functionality is important no matter the 'new'-Methods in CChild and CGrandChild class! ;)
             */

            //*DYNAMIC* Binding:
            int aa = pp.Footoo(); //CParent Pointer pp: so CParent FUNCTIONALITY; so ==1; WELL....... I was wrong
            /**   RUNTIME! - decisions based upon Object Type!
             *  so it's probably the CChild's Footoo-Method, b/c it's overriding CParent Footoo-Method - yes!
             *  But I still don't know why! It's a CParent Pointer, so should have CParent Functionality!?
             *  CParent<--CChild<--CGrandChild. as of right now: virtual<--override<--override.
             *  so we have Dynamic Binding happening here. 
             *  
             *  CAREFUL: virtual<--new means: Dynamic BUT, CompileTime, DataType (Poiter Variable), CPARENT Functionaliy! b/c *new* HIDES the method in CChild?!(compare to static binding l.16).
             *           virtual<--override: Dynamic, RunTime, Object Type (new CChild OR new CParent says which method is being called), CChild Functionality!
             */

            
            //Console.WriteLine(Child.Zahl);  //Child inherited Zahl 

            Parent p; Child c = new Child();    //parent p ref to Child clas obj and Chilc c ref to Chíld class object
            p = new Child(1,2,3,4); /**I want Child class object with Parent Functionality, that means: incl. ALL PRIVATE fields and Private Methods!!!*/
            //c = new Parent(); //still not possible
            int n, m; byte b = 100; n = b; Console.WriteLine(n);    //byte can implicitly be converted to int, but not the other way!
            // c = new Parent(); IS WRONG b/c Child class variable 'c' cannot access PubB from Parent object! 
            //  p.PubB does not exist.
            p = c;   //what is happening here? it's IMPLICIT CASTING! Parent Private MEMBERS accessible from within!
            /* c is a Child class reference variable, p can ref to Parent class and to Child class!
             * c=p would mean that Child class reference variable (c) can refer to Parent Class and Child class, but 'c' CANNOT REFER to PARENT CLASSS 
             * dem Parent wird ein Child-Obj zugewiesen ('c# steht als Referenz für Child class object da!)
             * dem Child kann kein Parent Class object zugewiesen werden, da das Parent-Obj. nicht die Funktionen und Parameter hat, auf die 'c' Zugriff hätte!
            */
            /** Third: ?? - Operator:     object y = x ?? z;
             * If x is !null then x will be assigned to y else z will be assigned to y!
             * what about c=(p as Child) ?? z;   ?  YESS!
             * tries to cast, if successful: c=(Child)p; else c = z which is another ref to a Child class obj!
             */

            /** Funktionsweise des AS-Operators:  c = p as Child; +++ IS-Operator +++
             * if(px is Child) { c = (Child)px; } else { c = null; } //c=null
             * If px is referring to object of Class Child or Class GrandChild make (explicit) DownCast else set c to null.
             * 
             * if(p is Child) { c = (Child)p; } else { c = null; } //c= Downcasted (Child)p :)
             * use AS operator when the code gets complicated. Cast only when 100% sure!
             */

            /** Now that I got it, let's take a look at AS-Operators
             * I know I can do this here:  c=(Child)p IF 'p' was assigned a Child class object before. Now what is 'c = p as Child;'?
             * c = p as Child; Console.WriteLine(p); //OUTPUTs: Child!
             * now let's take Parent px = new PARENT(); and do this:  c = px as Child; AS is an Operator, it's not Casting directly
             * Console.WriteLine(c.getType()); //OUTPUTs: EXCEPTION. What does it mean? CAST HAS FAILED. Null was returned.
             * FUN: Console.WriteLine(c==null); //OUTPUTs: TRUE
             */
            Parent px = new Parent();
            // nope: c = (px as Child)? /*c=*/(Child)p : c=null;
            if(px is Child) { c = (Child)px; } else { c = null; } //same as: c=px as Child :))
            Child z = new Child();
            c = (p as Child) ?? z;  // THIS IS POSSIBLE!!!



            /** We can do Explicit Casting like this:
             * c = (Child)p; works b/c 'p' is a ref var for a CHILD Class Object!
             * Side Effects are: if p refers to instantance Child class this works. If the p was to refer to a Parent class object, this would not work.
             * This is called Down-Casting. Here I want Child Functionality BACK! So EITHER full Child Functionality w/ Child Var OR PARENT FULL Functionality (Privte Members) w/Parent class Var!
             * Parent-To-Child-Casting --> must be EXPLICIT like this: c = (Child)p; DOWNCASTING only by EXPLICIT Casting!
             * Child-To-Parent-Casting can be Implicit --> p = c; b/c 'p' already pointed to Child class object!
             * Child-Var = Parent-Var CAN NEVER WORK, except with Downcasting, when Parent-Var was assigned a Child class object!     
             */

            Parent p3 = new Parent();
            // No: Child c3 = new Parent();

            Parent p2 = new Child(1,2,3,4);
            //p2.PubB does not exist either! b/c p and p2 have only access to Parent Class Members. Why then create Child class obj..?
            /** that's why:
             * The reason you might still want to create a Child object and reference it with a Parent variable is to take advantage of polymorphism. This allows you to write more flexible and reusable code.
             * For example, you can pass a Child object to a method that expects a Parent parameter, and the method can work with any object that is derived from Parent.
             * 
             * VERY IMPORTANT for OOP!
             * 
             */


            /** explanation: Phone<-MobilePhone<-SmartPhone
             * Phone ph = new MobilePhone(); ph.Call(); // works
             * MobilePhone mb = new SmartPhone; mb.Browse(); //works
             * SmartPhone sp = new MobilePhone(); sp.Browse(); //not possible! a MobilePhone object CANNOT BROWSE
             */

            /** Parent Variable p can be assigned to Child class object; "Parent is Child"
             * Child Variable cannot be assigned to a Parent class object
             */

            /** what happens at parameterized Child class Instantiation is:
             * 1. touch param constr. Child class (not run)
             * 2. run paramLESS constr. Parent class
             * 3. run parameterized constr. Child
             * finished. At no point of time there was the parameterized Constr. Parent class even touched. I checked with paramLESS constr. Parent class only!
             * CHILD class Constr. OVERRIDES Parent class paramLESS constructor!!! i.e. set PubA @ Parent constr to 1 and PubA @ Child constr to 2.
             */

            /** what happens at parameterized Child class Instantiation with ':base(PriA,ProA,PubA)'
             * 1. ':base(PriA,ProA,PubA)' is touched @Child class (from param-Constr. @Child class)
             * 2. ':this()' is touched @Parent class parameterized Constr.
             * 3. paramLESS constr @Parent class is RUN? !!!YES!!!
             * 4. ':this()' is accessed and parameterized constr. @Parent class is RUN
             * 5. ':base(PriA,ProA,PubA)' is accessed and parameterized constr. @Child class is RUN
             * finished! compare to Instantiation Comment (l.12-18) above
             * 
             */

            /** what is needed when I create a Child class object via parameterized Constr.
             * 1. Ensure that all members of Child AND Parent (incl. private Parent members) are set as params in Child constr. (here)
             * 2. Ensure that :base(AllParentparamsEvenPrivateOnes) is appended to constr. w/params; optionaly in body I can put additional {code;methods; etc;}
             * 3. pass data via :base is optional and how many params are passed depends upon the project
             * This is the correct approach for writing Constructors in Child class and Parent class
             * Child constr. overrides Parent constructor, that's why the Parent's constr. comes first. -->Execution order: Parent class constr., then Child class constr.
             */

            /** now what do I need to change, if I deliberately choose to have NO paramLESS constr. @Parent class?
             * 1. delete any Parent instance, that is made with paramLESS constr.! yes, that was my last and 'longest' mistake
             * 2. delete ':this()' @Parent class constr., so that it does not call the paramLESS automatically
             * 3. ':base(0,0,0)' needs to be added to paramLESS constr. @Child class
             * 
             */

            /** Notes by Mr. Sandeep Soni
             * The Protected member of Parent Class cannot be accessed in a Child class method that instantiates Parent p = new Parent(); inside Child class this is not possible: ## p.ProA = 10; ##
             * When an object of Child class is created all the data members of the Child and the Parent class are put into allocated memory no matter whether they are Private or Protected or Public
             * Whenever Child class is created, Parent constructor is executed FIRST, b/c only then Child class constr. can OVERRIDE Parent class constr. if needed!
             * Every Child class constructor by default first calls paramLESS constr. of Parent class!
             * using ':base(params)' we can explicitly call a specific constr. (according to params (constr. Overload)). note here that that specific Parent constr. always calls paramLess Parent constr. first
             * the visited or as I said the 'touched' Child class constr. can pass parameters to the Parent class constructor using public Child(int x, int y, int z) : base(x,y,z){}
             * It is recommended that a Child class constr. passes Parent class members to Parent class Constr. so that Parent class Constr. initalizes its class members
             * so that the Child class Constr. only initializes its own class members!
             * 
             * Plus there's some specialties to if I want or do not want to have a paramLESS constr @Parent class
             * if I do not want one: delete ':this()' @parameterized Constr @Parent class and add to Child paramLESS Constr. '_base(0,0,0)'!
             * ...if there is no paramLESS Constr. @Parent class, EVERY Child class Constr. must explicotly link to any other Constr. @Parent class 
             * 
             */
        }
    }
}