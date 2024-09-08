using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceDemoApp
{
    /**   One thing is going to exist in multiple forms and if there is a common functionality in each form
     *    but implemented in a different way - This is Polymorphism (not just binding)
     *    
     *    Driving a Vehicle: driving scooter is possible but in a different way compared to driving a car
     *    
     *    I want to write to a DB. My Database can take the form of MySQL or SQLite (Mr. Soni says Oracle or SQL) server.
     *    
     *    In polymorphism we have one thing which can take any of the forms provided at RUNTIME and based on the FORM it provides according functionality
     *    *THAT is the Knackpunkt! Runtime. before we had methods, inheritance etc but functions were 'clear' @Compilation Time -- need to check this statement!
     *    
     *    using Parent p = Child(); and doing some if and whatever operations function p.Foo() can be of class Child or Parent depending upon BINDING options. This statement is definately true.
     *    
     *    Now we don't want polymorphism via (like line 19) but rather using INTERFACES! yay
     *    
     *    
     *    Interface is all the Public Members of a Class! = collection of related PUBLIC and ABSTRACT methods or PUBLIC ABSTRACT properties or Events but 
     *    we do not worry about their implementation (right now or ever, ever ever?)
     *    
     *    An Interface is a PURELY ABSTRACT Class but I (still) have to ensure that each and every member is declared as abstract!
     *    
     *    what is this? A variable of type interface can refer to an object of any class implementing that interface! 
     *    
     *    Use Interface, use properties, make private fields to properties according to Encapsulation
     *    
     *    EEEERRRRR Interface Member CAN BE Protected!!!!!!!!!!!!!!!!!
     */

    /** IF(condition){return;} Stops static void Main and exits Program.               
     */
    internal class Polymorphism
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.Write("Please provide Dimension: ");
                    double dimension = Convert.ToDouble(Console.ReadLine());

                    Console.Write("Please provide Figure (CIRCLE/square: ");
                    string eingabe = Console.ReadLine().ToUpper();
                    IFigure fig; // IFigure variable is possible at every class that implements that Interface. CAVE: IT's NOT the parent class! It's just (convenient) Polymorphism!
                    if (eingabe == "Q") { break; }
                    else if (eingabe == "SQUARE") { fig = new Square(dimension); }
                    else { fig = new Circle(dimension); }
                    Console.WriteLine("The perimeter of {0} is: {1}", fig.GetType().Name, fig.getPerimeter()); Console.ReadKey(); Console.Clear();
                }
                catch
                {
                    throw new ApplicationException("type a number. use , not . as comma");
                }
            }
        }

        public interface IFigure
        {
            //public Figure() { } NO CONSTRUCTORS @ Interfaces!
            public abstract double Dimension { get; set; }
            public abstract double getPerimeter();
        }

        public class Circle : IFigure       // Class Circle IMPLEMENTS interface Figure; we don't say inherits here!
        {// We are not overriding, it's an interface, we just have to put them in the class
            private double radius;
            public double Dimension { get { return this.radius; } set { this.radius = value; } } //PUBLIC IMPLEMENTATION
            public Circle(double radius) { this.Dimension = radius; }
            public double getPerimeter()
            {
                return Math.PI * 2 * this.radius;
            }
        }

        public class Square : IFigure
        {
            private double sidelength;
            public double Dimension { get { return this.sidelength; } set { this.sidelength = value; } }
            public Square(double sidelength) { this.Dimension = sidelength; }
            double IFigure.getPerimeter()   //EXPLICITIMPLEMENTATION, also public?
            {
                return 4 * this.sidelength;
            }
        }
    }
}
