using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceDemoApp
{
    public class Child : Parent //Parent is BASE class or SUPER class; Child is SUB class.
    {
        public int PubB;        //Field members in ALLOCATED memory total: 4--> PubA,PubB,PriA,ProA when Child Class object is created
                                // only public and protected members of the Parent class are inherited by Child class
        
        //PubA = 2; //  idk why I tried this but it was good. Stay positive. Now you know better
        //ProA = 3; //  same
        static Child() {}
        public Child() : base(0, 0, 0) { PubA = 2;} //:base(0,0,0) the ie.e parameteriezed class constr. when Child class object is instantialized w/o params
        // if ':base(PriA, ProA, PubA)' nicht drin: cc.PriA=0; WENN DRIN, dann ist  cc.PriA=1, obwohl PriA restricted to Child obj cc!
        // if ':base(PriA, ProA, PubA)' DRIN, dann ist '{this.ProA = ProA; this.PubA = PubA; this.PubB = PubB;}' nicht mehr nötig, 
        //all data we wanted to give to the parent class, we did via :base(allparams), not separately in constr. body '{...}' ;)
        public Child(int PriA, int ProA, int PubA, int PubB) : base(PriA, ProA, PubA) { /*this.PriA = PriA; this.ProA = ProA; this.PubA = PubA; */this.PubB = PubB; }
        /** Params of Child Constructor w/o :base(...)
         * how many params do I recommend? from what I learned so far only 1: PubB! WRONG: ALL 4 should be initialized, EVEN the PRIVATE ones of Parent Class!!!!!
         * but private Parent members are not accessible by Child class. soo..  Parent p as parameter? no.
         * l. 20: this.PriA is private Parent member. Access w/ public pubPriA and get{]set{}? Mr. Soni says to comment out and wait until I can understand. ok I will do that.
         * At the time providing a constructor for the Child class do not restrict yourself to accessable members but instead DO INCLUDE PRIVATE MEMBERS of Parent class as well!!!!!!!!!!!!!!!!!!!!!!
         */
        /** Params of Child Constructor w/base(...)!
         * 
         * 
         */

        public void Foo()   
        {
            this.PubA = 1;
            this.PubB = 1;
            Child c = new Child(); //
            c.PubA = 1;
            c.PubB = 1;

            //Parent p = new Parent();
            //p.PubA = 1;
            //p.ProA = 1; NOT POSSIBLE --> SPEACIAL CASE here. normally I would think yes, b/c it's the Parent's Type object p.
            //but it doesn't have a thing to w/ the Type here at first. We're here at Foo Method, 
            /** Explanation
             * Protected members of Parent class CANNOT be accessed through Parent object reference inside Child class!
             * whew! I mean ok, but wow.
             * talking about line 29.
             */
        }
    }
}
