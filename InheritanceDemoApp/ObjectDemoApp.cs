using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace InheritanceDemoApp
{
    class ObjectDemoApp
    {
        static void Main(string[] args)
        {
            Point pt1 = new Point() { X = 19, Y = 19 }; //shorter Form of Initialization:  pt.X = 10;pt.Y = 10;
            //     { X = 10, Y = 10 };  is called OBJECT INITIALIZER
            Console.WriteLine(pt1);  //System.Project.ClassName
            Console.WriteLine(pt1.ToString());   //  where is ToString() Method located? It comes from the object class

            //ToString()-Method is a VIRTUAL Method!! soo what can we do? we could override it? oh yeah!

            Point pt2 = new Point() { X = 19, Y = 19 }; Console.WriteLine(pt2.Equals(pt1)); //Equals(): comparing REFERENCES! 

            Console.WriteLine(pt1.GetHashCode());   //Uninque number for every object! so it's the object ID
            Console.WriteLine(pt2.GetHashCode());

            /**  Class Loader loads class and it is remembered by its TYPE Instance
             * look at object instantiation, it's *not* an abstract class
             */
            Type tp1 = pt1.GetType(); Type tp2 = pt2.GetType(); Console.WriteLine(tp1==tp2);

            Object ob = new Object(); Console.WriteLine(ob.GetHashCode()); //parent pointer, parent obj -->parent Method (dynamic binding)
            
        }
        //after covering Collections Topic overriding GetHashCode will make more sense!
        public class Point : Object // ALL Classes I create are automatically inherited from OBJECT CLASS .NET Framework!
        {
            /** Object Class supports all classes in the .NET hierarchy and provides low-level services to derived classes.
             *  This is the ULTIMATE Base class of all .NET classes; it is the root of the TYPE Hierarchy!
             */
            public int X, Y;    //due to no construcor we have not initialized X or Y.

            /**   It's usual to override ToString, Equals and GetHashCode Methods!
             */

            //so let us override ToString-Method:             (+Equals() +GetHashCode())
            public override string ToString()       //Point is Child class, if we override Parent method dynamically this is what we get
            {
                return "X = " + X + ", Y = "+Y;
            }
            //if one overrides Equals, one should also override GetHashCode()-Method!
            public override bool Equals(object? obj)    //remember Object is Parent sooo casting, you recall? ;)
            {
                // No Access: obj.X  b/c Parent cannot access child class members! Cast obj to Child!
                Point p = (Point)obj;
                return this.X == p.X && this.Y == p.Y;  // now Equals compares Data, not References!
            }

            public override int GetHashCode()   //change this way: if Equals==true, set one hashcode for both objects.
            {
                //Members also have a Hash Code 
                int hashx = X.GetHashCode();
                int hashy = Y.GetHashCode();
                //Create alogorithm for unique number using x and y!
                int hash;
                if((hashx+hashy)%2!=0) { hash = (hashx % 9) * (hashy % 8) + hashy * hashx - (hashy % 6) ; }
                else { hash = ((hashx+15) % 9) * ((hashy+3) % 8) + (hashy % 7) + hashy * hashx - hashx % 4 + 3*(hashx%9); }
                return hash;
            }
        }
    }
}
