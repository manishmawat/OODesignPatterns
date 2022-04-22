using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral
{
    class ChainOfResponsibilityPattern
    {
        Approver manager = new Manager();
        Approver director = new Director();
        Approver vicePresident = new VicePresident();

        public void InitiateApproval()
        {
            manager.SetSuccessor(director);
            director.SetSuccessor(vicePresident);

            Purchase purchase = new Purchase(9000, 1, "bought new device");
            manager.ProcessRequest(purchase);
        }
    }

    abstract class Approver
    {
        protected Approver successor;

        public void SetSuccessor(Approver successor)
        {
            this.successor = successor;
        }
        public abstract void ProcessRequest(Purchase purchase);
    }

    class VicePresident : Approver
    {
        //approve any amount less than 10000
        public override void ProcessRequest(Purchase purchase)
        {
            if(purchase.Amount<10000)
            {
                Console.WriteLine("Vice President approved the purchase");
            }
            else
            {
                successor.ProcessRequest(purchase);
            }
        }
    }

    class Director : Approver
    {
        //approve any amount less than 5000
        public override void ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount < 5000)
            {
                Console.WriteLine("Director approved the purchase");
            }
            else
            {
                successor.ProcessRequest(purchase);
            }
        }
    }

    class Manager : Approver
    {
        //approve any amount less than 2000
        public override void ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount < 2000)
            {
                Console.WriteLine("Manager approved the purchase");
            }
            else
            {
                successor.ProcessRequest(purchase);
            }
        }
    }

    class Purchase
    {
        private int amount;
        private int number;
        private string purpose;

        public Purchase(int amount, int number, string purpose)
        {
            this.amount = amount;
            this.number = number;
            this.purpose = purpose;
        }
        public int Amount { get { return this.amount; } }
    }
}
