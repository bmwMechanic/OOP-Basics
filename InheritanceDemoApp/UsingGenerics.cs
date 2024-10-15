using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceDemoApp
{
    public class UsingGenerics
    {
        //public int<Car> number;
        int[] intArr = { 1, 2, 3 };
        double[] doubleArr = { 1.0D, 2.0D, 3.0D };
        string[] stringArr = { "1", "2", "3" }; //String like this as well. In Java String not string!
        //turn the method into a generic one:
        public static void DisplayElements<Thing>(Thing[] array)
        {
            foreach(var x in array)
            {
                Console.Write(x + " ");
            }
        }
        static void Main(string[] args)
        {
            UsingGenerics ug = new UsingGenerics();
            DisplayElements(ug.intArr); Console.WriteLine();
            DisplayElements(ug.doubleArr); Console.WriteLine();
            DisplayElements(ug.stringArr); Console.WriteLine();

            
            //          now with GenericClass<Thing>
            var ugen = new GenericClass<string>("36 hours"); Console.WriteLine(ugen.Data); //well ok, but too easy

            //          a little more complicated Example:
            NextClass nc = new NextClass();
            var ugen1 = new GenericClass<string>("37 hours"); nc.games.Add(ugen1);   //needs improvmentö
            var ugen2 = new GenericClass<string>("38 hours"); nc.games.Add(ugen2);  
            foreach(var x in nc.games)
            {
                Console.WriteLine(x.Data);
            }
            //okay works!
            Console.WriteLine("trying custom..");
            //now custom method:
            foreach(var x in nc.games)
            {
                nc.PrintCustom(nc.games);
            }

            //smth different: this time inside generics class: also a print method but a little different
            ugen.PrintCustomGen();  //Data is a generic string!
            ugen1.PrintCustomGen();
            ugen2.PrintCustomGen();
        }
    }

    public class NextClass
    {
        public List<GenericClass<string>> games = new List<GenericClass<string>>();
        public void PrintCustom<Type>(Type thing)
        {
            Console.WriteLine($"custom output: {thing}");
        }
    }

    public class GenericClass<Thing>
    {
        public Thing Data { get; set; }
        public GenericClass(Thing data)
        {
            this.Data = data;
        }
        public void PrintCustomGen()
        {
            Console.WriteLine(this.Data);
        }
    }
}
