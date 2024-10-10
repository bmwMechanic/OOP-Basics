using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceDemoApp
{
    public class ConstantsAndEnums
    {
        public const double Phy = 1.618D;
        static public double Calc;
        //I want to use numbers for weekdays --> 0 can be Sunday or Monday... so INT is not a solution because of confusion
        //string is not a solution as well beacause it's variable tha can be changed to "holiday" which is not a weekday... soooo..ENUMs
        static public Weekday wd; //why enums? because it brings more clarity to code!
        static public int n;

        static void Main(string[] args)
        {
            Calc = Phy * 10 * 10;                           //Phy will get replaced by 1.618 and then the code will be compiled
                                                            //          If we reverse-engineer, we only get this:  1.618 * 10 * 10; we will never see the Constant Phy!
                                                            //          Constants add readability to the code, that's why we use them!
                                                            //          Constants are always in UPPER CASE
                                                            //          Never say "constant variable"! Either Constants OR Variables
                                                            //          Constants are not ianstantiated.
            wd = Weekday.Monday; Console.WriteLine(wd); //Monday stays forever 1 now!

            n *= (int)wd; //Whenever we want to assign the INT of an ENUM, we have to explicitly cast it
            Console.WriteLine(n); n = 2;
            wd = (Weekday)n; //Casting here needed as well.
            Console.WriteLine(wd.ToString()+"  "+(int)wd); // index 2 of enum Weekday is Wednesday! w/casting: int can be used!
            //Console.WriteLine(wd); by default uses the .ToString() method for enums!
            //what about
            Console.WriteLine(Weekday.Tuesday.ToString());  //works as well

            /** By using enums, in reverse engineering we will only see the direct inerger values; i.e. 0 for Weekday.Monday; it's for us coders easier to
             *  use enums that are integers or bytes or whatever else is allowed (line 46) b/c it's a text. How can I use them intelligently? see Joplin
             *  try to use enums more often than sealed classes, b/c Constructors are difficult to serialize
             */
        }
    }

    /** ENUM is a collection of RELATED CONSTANTS identified by a common names which can be used as a DataType and variable. That Variable can can have
     *  any of the values that are listed in the designated enum class!
     */

    public enum Weekday:int //enums can only be of Type byte,sbyte,short,ushort,int,uint,long or ulong
    {
        Monday,Tuesday,Wednesday,Thursday,Friday,Saturday,Sunday,        //all of these are constants! first, So Monday is 0.
        //a=0,b,c,d,e,f,g,h,                                               //since a is set to 0, all other increase by 1. 0 equals to Monday and to a... and so on; h is 7 and "alone"
        //i=1,j,k,l,m,n,o,p

    }
}
