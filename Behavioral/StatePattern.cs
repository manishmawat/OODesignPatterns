using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral
{
    /// <summary>
    /// The State design pattern allows an object to alter its behavior when its internal state changes. The object will appear to change its class.
    /// In this code example
    /// This structural code demonstrates the State pattern which allows an Account to behave differently depending on its balance. 
    /// The difference in behavior is delegated to State objects called RedState, SilverState and GoldState. These states represent overdrawn accounts, starter accounts, and accounts in good standing.
    /// </summary>
    class StatePattern
    {
        public void CallState()
        {
            Context_Account account = new Context_Account("James");

            Console.WriteLine($"Cuurent Account Balance is {account.Balance}");
            account.Deposit(10);
            account.Deposit(25);
            Console.WriteLine($"Cuurent Account Balance is {account.Balance}");

            account.Withdraw(20);
            Console.WriteLine($"Cuurent Account Balance is {account.Balance}");

            account.Withdraw(20);
            Console.WriteLine($"Cuurent Account Balance is {account.Balance}");
        }
    }

    /// <summary>
    /// Context
    /// defines the interface of interest to clients
    /// maintains an instance of a ConcreteState subclass that defines the current state.
    /// </summary>
    public class Context_Account
    {
        private State_AccountTypes state;
        private string owner;

        // Constructor

        public Context_Account(string owner)
        {
            // New Account are Silver by default
            this.owner = owner;
            this.state = new SilverState_ConcreteState_AccountTypes(0.0, this);
        }

        public double Balance
        {
            get { return state.Balance; }
        }
        public State_AccountTypes State
        {
            get { return state; }
            set { this.state = value; }
        }

        public void Deposit(double amount)
        {
            state.Deposit(amount);
            Console.WriteLine("Deposited {0:C} --- ", amount);
            Console.WriteLine(" Balance = {0:C}", this.Balance);
            Console.WriteLine(" Status  = {0}", state.GetType().Name);
        }
        public void Withdraw(double amount)
        {
            state.Withdraw(amount);
            Console.WriteLine("Withdrew {0:C} --- ", amount);
            Console.WriteLine(" Balance = {0:C}", this.Balance);
            Console.WriteLine(" Status  = {0}\n",
                this.State.GetType().Name);
        }
        public void PayInterest()
        {
            state.PayInterest();
            Console.WriteLine("Interest Paid --- ");
            Console.WriteLine(" Balance = {0:C}", this.Balance);
            Console.WriteLine(" Status  = {0}\n",
                this.State.GetType().Name);
        }
    }

    /// <summary>
    /// Abstract State Class
    /// defines an interface for encapsulating the behavior associated with a particular state of the Context.
    /// </summary>
    public abstract class State_AccountTypes
    {
        protected Context_Account account;
        protected double balance;

        protected double interest;
        protected double lowerlimit;
        protected double upperLimit;

        public Context_Account Account
        {
            get { return account; }
            set
            {
                this.account = value;
            }
        }
        

        public double Balance
        {
            get { return balance; }
            set { this.balance = value; }
        }

        public abstract void Deposit(double amount);
        public abstract void Withdraw(double amount);
        public abstract void PayInterest();
    }

//-------------------------------------------------------------------------Different Concrete states for account type------------------------------------------------------------------------------------

    /// <summary>
    /// Concrete State class
    /// each subclass implements a behavior associated with a state of Context
    /// </summary>
    public class RedState_ConcreteState_AccountTypes : State_AccountTypes
    {
        private double serviceFee;

        public RedState_ConcreteState_AccountTypes(State_AccountTypes state)
        {
            this.balance = state.Balance;
            this.account = state.Account;
            Initialize();
        }

        private void Initialize()
        {

            // Should come from data source
            // this value could change based on business rules

            interest = 0.0;
            lowerlimit = -100;
            upperLimit = 0.0;
            serviceFee = 15.00;

        }

        public override void Deposit(double amount)
        {
            this.balance += amount;
            StateChangeCheck();
        }

        public override void PayInterest()
        {
            throw new NotImplementedException();
        }

        public override void Withdraw(double amount)
        {
            balance -= serviceFee;
            Console.WriteLine("No funds availables");
        }

        private void StateChangeCheck()
        {
            if(balance>upperLimit)
            {
                
            }
        }
    }

    /// <summary>
    /// Concrete State class
    /// each subclass implements a behavior associated with a state of Context
    /// </summary>
    public class SilverState_ConcreteState_AccountTypes : State_AccountTypes
    {
        private double serviceFee;

        public SilverState_ConcreteState_AccountTypes(State_AccountTypes state)
        {
            this.balance = state.Balance;
            this.account = state.Account;
            Initialize();
        }

        //this constructor is created to cater the default account state
        //As we are considering Silver as default account state
        public SilverState_ConcreteState_AccountTypes(double balance, Context_Account account)
        {
            this.balance = balance;
            this.account = account;
            Initialize();
        }

        private void Initialize()
        {

            // Should come from data source
            // this value could change based on business rules

            interest = 0.0;
            lowerlimit = 0.0;
            upperLimit = 1000.0;

        }

        public override void Deposit(double amount)
        {
            this.balance += amount;
            StateChangeCheck();
        }

        public override void PayInterest()
        {
            balance += interest * balance;
            StateChangeCheck();
        }

        public override void Withdraw(double amount)
        {
            balance -= amount;
            StateChangeCheck();
        }

        private void StateChangeCheck()
        {
            if (balance < lowerlimit)
            {
                account.State = new RedState_ConcreteState_AccountTypes(this);
            }
            else if (balance > upperLimit)
                account.State = new GoldenState_ConcreteState_AccountTypes(this);
        }
    }

    /// <summary>
    /// Concrete State class
    /// each subclass implements a behavior associated with a state of Context
    /// </summary>
    public class GoldenState_ConcreteState_AccountTypes : State_AccountTypes
    {
        private double serviceFee;

        public GoldenState_ConcreteState_AccountTypes(State_AccountTypes state)
        {
            this.balance = state.Balance;
            this.account = state.Account;
            Initialize();
        }

        private void Initialize()
        {

            // Should come from data source
            // this value could change based on business rules

            
            interest = 0.05;
            lowerlimit = 1000.0;
            upperLimit = 10000000.0;

        }

        public override void Deposit(double amount)
        {
            this.balance += amount;
            StateChangeCheck();
        }

        public override void PayInterest()
        {
            this.balance += interest * balance;
            StateChangeCheck();
        }

        public override void Withdraw(double amount)
        {
            this.balance -= amount;
            StateChangeCheck();
        }

        private void StateChangeCheck()
        {
            if (balance < 0.0)
                account.State = new RedState_ConcreteState_AccountTypes(this);
            else if(balance<lowerlimit)
            {
                account.State = new SilverState_ConcreteState_AccountTypes(this);
            }
        }
    }
}
