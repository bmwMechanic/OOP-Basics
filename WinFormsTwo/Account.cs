using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsTwo
{
    public class Account    //here now: FULLY ENCAPSULATED CLASS; but what about private get and private set?
    {
        //here only fields!
        private int iD;
        private string name;
        private decimal balance;   //in AccForms we do not want to change Balance, but we want to see the balance; we want to GET the Balance
        private bool iDAlreadySet = false;
        private bool nameAlreadySet = false;
        private string privateSetExample;
        private string privateSetExample2;
        private bool privateBoolExample = false;    //no get|set just for demonstration below in ExampleMethod1......

        //something else:   IMPLICIT IMPLEMENTATION;; --  ALT+SHIFT + DownArrow and type  --
        public string Api { get; set; } // dynamic info requests from API-interfaces need to be implemented implicitly

        //if the class does not have any constructor the compiler will add one by default like this:  public ClassName(){}
        //if I choose to have a parameterized one and I additionally want to create an object with a parameterless constructor, it will not work.
        //then I have to add the parameterless constructor on my own. like this:  public ClassName(){}

        public Account() { /*common code for all constructors*/ } //parameterless constructor!
        public Account(int inputID, string inputName, decimal inputBalance) : this() { this.ID = inputID; this.Name = inputName; this.Balance = inputBalance; } //parameterized constructor! --> usually used for initialization of Field members. don't bypass Name-Property b/c of set-Method explained above
        //public Account(Account a) { this.ID = a.ID; this.Name = a.Name; this.Balance = a.Balance; } //Copy Constructor when we set a1=a it's still the same object the variables are referring to. sooo copy the OBJECT with another variable of course :). Example: a1=new Accout(a);
        //COPY CONSTRUCTOR made easily (eventually haha)
        public Account(Account a) : this(a.iD, a.name, a.balance) { }   //so yeah that's the deal. As a beginner I like the longer version

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

        public string Name  //public Balance cannot store data! it's just there to access private FIELDS :))
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

        public int ID   //iD should be set only once!
        {
            get
            {
                return this.iD;
            }
            set
            {
                if (iDAlreadySet)
                {
                    throw new ApplicationException("ID is already set. Reset is not possible. Please contact account manager.");
                }
                else
                { 
                    this.iD = value;
                    this.iDAlreadySet = true;
                }
            }
        }

        public string PrivateSetExample
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
         * but it's clear: if there's no extra method that checks, it needs to be checked in each method :) 
         */

        public void Withdraw(decimal amount)    //now I can use public property Balance b/c it's setter is private and now we have one haha :)
        {
            if(this.Balance - amount < 0)
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

        public void ExampleMehod1()
        {
            if (privateBoolExample)
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
