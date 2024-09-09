using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceDemoApp
{
    /**  When should we use explicit implementation?                   
     *  -when we implement MULTIPLE Interfaces with Same Method names
     */
    internal class ExplicitImplementation
    {
        static void Main(string[] args)
        {
            IExplicitImplementation expl;
            IExplicitImplementationTwo expltwo;
            TwoInterfaces iTwice;

            expl = new TwoInterfaces(); expltwo = new TwoInterfaces(); iTwice = new TwoInterfaces();
            /**  will 'expl' ever refer to an object 'expl' or 'expltwo' can not refer to? No! 
             * 
             */

            expl.Explode();// Interface var can call TwoInterfaces Class Members Only!
            expl.Implode();
            expl.Burn();    //if not set in Interface Interface var cannot use class only Members!

            //expltwo.Explode(); Does not exist in IExplicitImplementation, so cannot call that Method by I..Two interface
            expltwo.Implode(); expltwo.Burn();

            iTwice.Explode(); iTwice.Implode(); /*IMPLICT here @Implode*/ iTwice.Burn();
            ((IExplicitImplementation)iTwice).Implode(); //"up"-casting !
            ((IExplicitImplementationTwo)iTwice).Implode(); //"up"-casting ! for other interface

            expl = iTwice; //implicit CASTING
            iTwice = (TwoInterfaces)expl; //explicit CASTING

            //casting w/ two implemented Interfaces:
            expl = (IExplicitImplementation)expltwo;
            expltwo = (IExplicitImplementationTwo)expl;

            //now w/Inheritance
            IExplicitImplementation expl1;
            IExplicitImplementationTwo expltwo1;
            NowATest iTwice1;
            expl1 = new NowATest();
            expl1.Implode();
            iTwice1 = new NowATest(); iTwice1.Kiss();

            iTwice.Relax();
        }
    }

    public class OneExample
    {
        public void Relax() { Console.WriteLine("Relax. Greetings."); }
    }

    //Class Inheritance first, then all needed interfaces; I can make more interf inherit one member. --> then onlay both are present
    public class TwoInterfaces:OneExample, IExplicitImplementation,IExplicitImplementationTwo   //I can have 3 SAME Method names and each different in Function when used by different var ;)
    {//where do we get ahold of Relax-Method
        public void Explode() { Console.WriteLine("BOOM"); }
        //without this PUBLIC implementation of Implode Method iTwice could (only through casting ;)  ) access implode methods of explicitly implemented Implode methods ;)
        public void Implode() { Console.WriteLine("BÄÄM"); }   //yeah if both interfaces have exact same Methods yeah..
        public void Burn() { Console.WriteLine("Burn"); }   //PUBLIC IMPLEMENTATION
        void IExplicitImplementation.Implode() { Console.WriteLine("IExplicitImplementation.Implode"); } //EXPLICIT IMPL
        void IExplicitImplementationTwo.Implode() { Console.WriteLine("IExplicitImplementationTwo.Implode"); } //EXPL IMPL; NO public!
        public void Fool() { Console.WriteLine("lulu from TwoInterface Fool Method."); }
    }

    interface IExplicitImplementation
    {
        public abstract void Explode();
        public void Implode();
        public void Burn();     //now Burn works in TwoInterfaces class
    }

    interface IExplicitImplementationTwo
    {
        public void Implode();
        public void Burn();
        public void Fool();
    }

    public class NowATest:TwoInterfaces, IExplicitImplementationTwo     //Implementation Inheritance + extra IExplicitImplementationTwo to show how I can then implement explicitöy. 
    {
        public void Kiss() { Console.WriteLine("kiss"); }

        //What if I implement some Method explicitly and before it was public? hmm let's see
        void IExplicitImplementationTwo.Fool() { Console.WriteLine("lulu"); } // no Interfacces before - just inhertis everything in from TwoInterfaces class!  
        
    }
}
