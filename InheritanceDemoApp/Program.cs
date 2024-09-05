namespace InheritanceDemoApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(Child.Zahl);  //Child inherited Zahl 

            Child c = new Child();
            Child cc = new Child(1,2,3,4);

            /** what happens at parameterized Child class Instantiation is:
             * 1. touch param constr. Child class (not run)
             * 2. run paramLESS constr. Parent class
             * 3. run parameterized constr. Child
             * finished. At no point of time there was the parameterized Constr. Parent class even touched. I checked with paramLESS constr. Parent class only!
             * CHILD class Constr. OVERRIDES Parent class paramLSS constructor!!! i.e. set PubA @ Parent constr to 1 and PubA @ Child constr to 2.
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

            cc.Foo();

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
             */
        }
    }
}