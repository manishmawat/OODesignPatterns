using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral
{
    /// <summary>
    /// Momento design pattern is about capturing the moments about object.
    /// It keeps a internal state or copy of original (originator) object and can restore it when required.
    /// In this pattern, we have 
    /// 1. Momento - store internal state of the Originator object. The momento may store as much or as little of the originator's internal state as nesessary at its originator's discretion. Protect against access by object of other than originator.
    /// 2. Originator - creates a momento containing a snapshot of its current internal state. uses the momento to restore its internal state.
    /// 3. Caretaker - is responsible for the momento's safekeeping. Never operates on or examine the contents of a momento.
    /// </summary>
    class MomentoPattern
    {
        public void CallMomento()
        {
            SalesProspect salep = new SalesProspect();
            salep.Name = "Customer-1";
            salep.Phone = "1234567890";
            salep.Budget = 2500.0;

            // Store internal state
            ProspectMemory caretaker = new ProspectMemory();
            caretaker.Momento = salep.SaveMomento();

            //Continue working on original/originator object

            salep.Name = "Real Name";
            salep.Phone = "4232345467";
            salep.Budget = 10000.0;

            //Change your mind or did something incorrect
            //Restore the state

            salep.RestoreMomento(caretaker.Momento);



        }
    }

    /// <summary>
    /// ORIGINATOR
    /// The original object
    /// </summary>
    public class SalesProspect
    {
        string name;
        string phone;
        double budget;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                Console.WriteLine("Name:  " + name);
            }
        }

        public string Phone
        {
            get { return phone; }
            set
            {
                phone = value;
                Console.WriteLine("Phone:   " + phone);
            }
        }

        public double Budget
        {
            get { return budget; }
            set
            {
                budget = value;
                Console.WriteLine("BUdget:   " + budget);
            }
        }

        public Momento SaveMomento()
        {
            return new Momento(name, phone, budget);
        }

        public void RestoreMomento(Momento momento)
        {
            Console.WriteLine("\nRestoring state");
            this.Name = momento.Name;
            this.Phone = momento.Phone;
            this.Budget = momento.Budget;
        }
    }


    /// <summary>
    /// MOMENTO
    /// </summary>
    public class Momento
    {
        //Here we stored the whole object but We can keep the individual properties in this momento/state object as required.
        SalesProspect state;

        string name;
        string phone;
        double budget;

        public Momento(string name, string phone, double budget)
        {
            this.name = name;
            this.phone = phone;
            this.budget = budget;
        }

        public string Name { get { return name; } }
        public string Phone { get { return phone; } }
        public double Budget { get { return budget; } }
    }


    /// <summary>
    /// CARETAKER
    /// </summary>
    public class ProspectMemory
    {
        Momento mometo;
        public Momento Momento
        {
            get { return this.mometo; }
            set { this.mometo = value; }
        }
    }
}
