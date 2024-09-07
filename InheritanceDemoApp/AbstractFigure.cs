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
                    Figure fig;
                    if(eingabe == "SQUARE") { fig = new Square(dimension); }
                    else { fig = new Circle(dimension); }
                    Console.WriteLine("The perimeter of {0} is: {1}",fig.GetType().Name ,fig.getPerimeter()); Console.ReadKey(); Console.Clear();
                }
                catch 
                {
                    throw new ApplicationException("type a numer. use . not ,");
                }
            }
        }
    }

    public abstract class Figure 
    {
        public Figure() { }
        protected double Dimension; //this was a public abstract property at first, that's why 'so many Dimensions'...
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
}
