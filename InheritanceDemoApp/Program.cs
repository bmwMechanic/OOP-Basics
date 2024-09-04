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
        }
    }
}