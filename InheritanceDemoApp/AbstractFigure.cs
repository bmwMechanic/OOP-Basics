using InheritanceDemoApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace InheritanceDemoApp
{
    internal class AbstractFigure
    {
        static void Main(string[] args)
        {
            while(true)
            {
                try
                {
                    Console.Write("Please provide Dimension: ");
                    double dimension = Convert.ToDouble(Console.ReadLine());

                    Console.Write("Please provide Figure (CIRCLE/square: ");
                    string eingabe = Console.ReadLine().ToUpper();
                    Figure fig; //Absolutely OK, but new cannot be Figure ;)
                    if(eingabe == "Q") { break; }
                    else if(eingabe == "SQUARE") { fig = new Square(dimension); }
                    else { fig = new Circle(dimension); }
                    Console.WriteLine("The perimeter of {0} is: {1}",fig.GetType().Name ,fig.getPerimeter()); Console.ReadKey(); Console.Clear();
                    Console.WriteLine("just some test: {0}.",fig.x);
                }
                catch 
                {
                    throw new ApplicationException("type a number. use , not . as comma");
                }
            }
        }
    }
    
    /** Though in rare cases there can be an abstract class with NO abstract members inside it
     *  I cannot instantiate that abstract class But I can crate an object like above and assign it to a Child- or Grandchild class!
     *  Why then is statc there? Well, if static, then I could never do 'Figure fig;' I could work with an hypothetical double x var but it wouldn't work in the Child-
     *  or Grandchild classes!
     *  
     *  a class cannot be sealed AND abstract at the same time!
     *  
     *  An Abstract class can have everything a concrete class can have.
     *  An Abstract class cannot have 
     *  
     */

    public abstract class Figure 
    {
        public Figure() { }
        protected double Dimension; //this was a public abstract property at first, that's why 'so many Dimensions'...
        public double x = 10;
        public Figure(double dimension) { Dimension = dimension; }
        //protected abstract double x;  NO FIELDS allowed in ABSTRACT classes! Private disallowed!
        public abstract double getPerimeter();
    }
    public class Circle : Figure 
    {
        //public override double Dimension { get; set; }

        public Circle(double radius):base(radius) { }
        public override double getPerimeter()
        {
            return Math.PI * 2 * this.Dimension;
        }
    }

    public class Square : Figure
    {
        //public override double Dimension { get; set; }

        public Square(double sidelength) : base(sidelength) { }
        public override double getPerimeter()
        {
            return 4 * this.Dimension;
        }
    }

    public abstract class Paper
    {
        public int Pint;
        public abstract void Do();
        //protected abstract int something;    Fields in abstract class yes, but Abstract Fields in Abstract class - NO!
        public abstract int Something { get; set; } //{ get { return something; } set { something = value; } } methis not possible but simple Properties yes
    }
                              //  Static classes must derive from object!
                              //  Cannot inherit from Sealed Classes!
    public class Book : Paper
    {
        public override int Something { get; set; }       //so yeah - possible!
        //Book has now Pint and Pages as fields
        public int Pages;
        public override void Do() { }
    }
}
