using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceDemoApp
{
    public class Child : Parent //Parent is BASE class or SUPER class; Child is SUB class.
    {
        public int PubB;        //Field members in ALLOCATED memory total: 4--> PubA,PubB,PriA,ProA
                                // what about static fields?
        public void Foo()   
        { 

        }
    }
}
