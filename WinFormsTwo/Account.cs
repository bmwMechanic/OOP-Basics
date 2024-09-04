using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsTwo
{
    public class Account    //here now: FULLY ENCAPSULATED CLASS; but what about private get and private set?
    {
        /** Ahem, Properties {get;set;} can be static as well!
         * i.e.: I want to put a restriction on MinBalance
         */
        private static decimal minBalance;

        //static members are also called class members! so:
        //every object of Account class shall have this one or many or whatever static member fiels so the value is THE SAME for ALL objects of Account class!
        //but why public Mr. Soni? let's see why... wait... no init, no get or set, just the same; but not constant.... ahh I still don't get it
        //MinBal is not under the Ownership of objects! It's accessed by Account.MinBalance = 0; Plus it's a FIELD Class member
        //when are static members loaded into allocated memory? When class member is called the first time or when object is initialized the first time!
        //with the 1st usage of class member, CLR loads with the help of class Loader class into the allocated memory; one TYPE instance in CLR for all account objects!
        //Account.MinBalance becomes a GLOBAL variable in the project, b/c it's public(answer to first lines), it can be set or gotten --> left side of =  = and right side of it as well;
        //it can be used in any Class, in any File, in any Method! mostly I need encapsulation and interfaces, but sometimes a global variable can come in handy
        //private static fields are 'global' classwide, public static fields are glogal to the whole project
        public static decimal MinBalance
        {
            get
            {
                return minBalance;
            }
            set
            {
                if (value >= 0 && value <= 500) { minBalance = value; }
                else { throw new ApplicationException("Minimum Value must be between 0 and 500. You typed "+value); }
            }
        }
        

        //noW we are calling a STATIC CONSTRUCTOR!
        static Account()        // gets called when CLASS is LOADED the FIRST TIME. it does not get called after any following initialization of Account Class
        {
            System.Windows.Forms.MessageBox.Show("Class is loaded. Thus, this displays only once."); //return must not be provided! thus, here I need to say Console.WriteLine or MessageBox.Show()...
            //Usually the static var gets its data from DB; HERE is the IDEAL place to place that exact code! WOW, that info is IMPORTANT!
            /** obj creation in static constructor
            *Account a = new Account();
            *a.ID = 123456;
            *the object is loaded, created and destroyed. Memory for ClassTable of CLR is still allocated :)
            */
        }
        //a STATIC Construuctor cannot access MEMBER FIELDS or MEMBER PROPERTIES of classes, b/c they need to be instantiated!
        //a static Constructor is also called a static FIELD INITIALIZER 
        //a static DESTRUCTOR DOES NOT EXIST

        /** what happens when an object is created the first time?      1 - 3 only once
         * 1. Class is loaded by CLR
         * 2. Static Members are loaded and put in allocated memory for further usage (for futher instantiations of classes :) )
         * 3. Static Constructor is executed
         * 4. Object is created and Instance Members are loaded into allocated memory
         * 5. Instance Constructor is executed
         * 6. only 4+5 repeat for subsequent instantiation (=Instanziierung)
         * 
         * THIS. is a reference to current object; THIS. cannot be used for static class members!
         */

        //in short: static members are the same for all objects of that class, unlike instance members which differ from object to object :)

        //here only fields!
        private int iD;
        private string name;
        private decimal balance;   //in AccForms we do not want to change Balance, but we want to see the balance; we want to GET the Balance

        //something else:   IMPLICIT IMPLEMENTATION;; --  ALT+SHIFT + DownArrow and type  --
        public string Api { get; set; } // dynamic info requests from API-interfaces need to be implemented implicitly
                                        //get;set; b/c it CAN get or set private api field if existant;

        //if the class does not have any constructor the compiler will add one by default like this:  public ClassName(){}
        //if I choose to have a parameterized one and I additionally want to create an object with a parameterless constructor, it will not work.
        //then I have to add the parameterless constructor on my own. like this:  public ClassName(){}
        //OBJECT IS CREATED THEREFORE CONSTRUCTOR IS CALLED, then parameterized c is called... it's still just a function!

        private static int prevId;
        public Account() 
        { /*common code for all constructors*/ //i.e: auto increment id for each new object of Account class
            prevId++;
            this.iD = Account.prevId;
        } //parameterless constructor!

        public Account(string inputName, decimal inputBalance) : this() { this.Name = inputName; this.Balance = inputBalance; } //parameterized constructor! --> usually used for initialization of Field members. don't bypass Name-Property b/c of set-Method explained above
        //public Account(Account a) { this.ID = a.ID; this.Name = a.Name; this.Balance = a.Balance; } //Copy Constructor when we set a1=a it's still the same object the variables are referring to. sooo copy the OBJECT with another variable of course :). Example: a1=new Accout(a);
        //COPY CONSTRUCTOR made for easy usage(l.73) (eventually haha)
        public Account(Account a) : this( a.name, a.balance) { }   //so yeah that's the deal. As a beginner I like the longer version
        

        //Destructor OR Finalize Method!
        //important in i.e. C++ b/c if the constr. of one class create an object of a different type, and we destroy inital object, the other still exists... therefore --> destructor that destroys the 2nd object
        ~Account() {  } //99.9% in .NET don't worry about destructor. but outside, it is needed --> so write GC.Collect(); inside Destructor
        //if we use other frameworks than .NET (i.e. angular?), it's saved in unmanaged heap - no GC is working there!

        //from here on Properties
        public decimal Balance  //public Balance cannot store data! it's just there to access private FIELDS :))
//       encapsulation for benefit:  access restriction: what kind? read-only access :)
        {
            get
            {
                return balance;
            }
            private set                //"set": via a.Balance = 1000 is possible, but we don't want that. That's why PRIVATE set
            {
                this.balance = value;
            }
        }
        private bool nameAlreadySet = false;
        public string Name  //public Name cannot store data! it's just there to access private FIELDS :))
        {
            get
            {
                return this.name;
            }
            set
            {
                if (this.nameAlreadySet)
                {
                    throw new ApplicationException("Name is already set. Reset is not possible. Please contact account manager.");
                }
                else
                {
                    if (value.Length > 2)
                    {
                        this.name = value;
                        this.nameAlreadySet = true;
                    }
                    else
                    {
                        throw new ApplicationException("Name must be between 3 and 8 Characters");
                    }
                }
            }
        }

        //private bool iDAlreadySet = false;    //now not needed; ID sets itself automatically autoincrementing
        public int ID   //iD should be set only once!
        {
            get
            {
                return this.iD;
            }
            //set           //can be removed now, b/c iD is auto-incremented and set once; here: read-only
            //{
            //    if (iDAlreadySet)
            //    {
            //        throw new ApplicationException("ID is already set. Reset is not possible. Please contact account manager.");
            //    }
            //    else
            //    { 
            //        this.iD = value;
            //        this.iDAlreadySet = true;
            //    }
            //}
        }

        public void Withdraw(decimal amount)    //now I can use public property Balance b/c it's setter is private and now we have one haha :)
        {
            if (this.Balance - amount < /*this.*/MinBalance) //"this." may not be used b/c this refers to a field or property of an OBJECT! STATIC FIELDS only by name themselves!
            {
                throw new ApplicationException("Not enough funds for withdrawal");
            }
            else
            {
                this.Balance -= amount; //directly private field -- not any longer, b/c setter actived - PRIVATE setter activated
            }
        }

        public void Deposit(decimal amount)
        {
            this.Balance += amount;
        }

        /** when do I choose to label a Method to be static? How are they different from the instance members of the class?
         * Q: are methods stored in allocated memory? - NO, methods are not stored for each object in allocated memory; only ONCE
         * difference is the access of a static method: Account.StaticMethod1(); whereas insance method: a.Deposit(1000);
         * IF I do NOT need instance members within A method (i.e. just needed parameters are forwarded ) - why should I create an object? This is the time to create a public STATIC method
         * So call the static method via ClassName.MethodName(<params>); IMPORTANT: NOT a SINGLE instance MEMBER of the class may be used for STATIC class methods
         * 
         */
        // Example for static method: I want to compare 2 obj. within one class.
        public static Account GetAccountWithMoreBalance(Account a1, Account a2)     //no usage of current obj nor instance members
        {   //static method --> GLOBAL METHOD
            if (a1.Balance > a2.Balance)
            {
                return a1;
            }
            else return a2;
        }// Class method: create 2obj to be compared and 3rd (a3) to get the returned obj: a3 = Account.GetAccountWithMoreBalance(a1,a2)
        // is this possible: Account a3 = new (Account.GetAccountWithMoreBalance(a1,a2));? YESS! I tested it and it works perfectly

        public Account GetAccountWithMoreBalance(Account otherObj)     //no usage of current obj nor instance members
        {
            if (otherObj.Balance > this.Balance)
            {
                return otherObj;
            }
            else return this;
        }//instance method call like this: create Account class obj a1 and a2; a1 = a1.GetAccountWithMoreBalance(a2);


        //-------------------------//
        public string PrivateSetExample     //example for encapsulation
        {
            get
            {
                return privateSetExample;
            }
//            private set
//            {
////              here is code that thanks to "private set" does not need to be implemented in EVERY METHOD, that uses setter of PrivateSetExample
//                privateSetExample = value;
//            }
        }

        public string PrivateSetExample2
        {
            get
            {
                return privateSetExample2;
            }
            private set
            {
                if (privateBoolExample)
                {
                    privateSetExample = value;
                }
                else
                {
                    throw new ApplicationException();
                }
            }
        }

        /** Examples
         * so in ExampleMethod1 - 3 I need to check if the value to be setted fits the rules
         * but in ExampleMethod10 - 30 I do not, b/c THERE IS a private set-METHOD which is used every time a value is to be set
         * When to use? yeah... Just don't forget it and it will be useful someday
         * but it's clear: if there's no extra method that checks, it needs to be checked in each method separately :) 
         */

        private string privateSetExample;
        private string privateSetExample2;
        private bool privateBoolExample = false;    //no get|set just for demonstration below in ExampleMethod1......
        public void ExampleMehod1()
        {
            if (privateBoolExample)         //the bool has nothing to say, just there to be a code example, not to be run... 
            {
                privateSetExample = "someStringForExamplePurposes1";
            }
            else
            {
                throw new ApplicationException();
            }
        }
        public void ExampleMehod2()
        {
            if (privateBoolExample)
            {
                privateSetExample = "someStringForExamplePurposes2";
            }
            else
            {
                throw new ApplicationException();
            }
        }
        public void ExampleMehod3()
        {
            if (privateBoolExample)
            {
                privateSetExample2 = "someStringForExamplePurposes3";
            }
            else
            {
                throw new ApplicationException();
            }
        }

        public void ExampleMehod10()
        {
           privateSetExample2 = "someStringForExamplePurposes10";
        }
        public void ExampleMehod20()
        {
            privateSetExample = "someStringForExamplePurposes20";
        }
        public void ExampleMehod30()
        {
            privateSetExample2 = "someStringForExamplePurposes30";
        }
    }
}
