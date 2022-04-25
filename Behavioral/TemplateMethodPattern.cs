using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral
{
    /// <summary>
    /// Template method design pattern defines the skelton of an algorithm (steps to perform some business/process/task) in an operation, 
    /// deferring some steps to subclasses. This pattern lets subclasses redefine certain steps of an algorithm without changing the algorithm's structure.
    /// E.g.
    /// If some algorith needs to perform steps like
    /// class Default_Algo
    /// {
    ///     virtual TemplateMethod()
    ///         {
    ///             Step1()
    ///             Step2()
    ///             Step3()
    ///             Step4()
    ///         }
    /// }
    /// So to perform another algo with different steps, we will create another class and inherit this class and override the methods with new logic
    /// class newAlgo
    /// {
    ///     override TemplateMethod()
    ///         {
    ///             newStep1();
    ///             ....
    ///             ....
    ///         }
    /// }
    /// </summary>
    class TemplateMethodPattern
    {
        public void CallTemplateMethod()
        {
            DataAccessor dataAccess = new ConcreteClass_Categories();
            dataAccess.Run(1);

            dataAccess = new ConcreteClass_Products();
            dataAccess.Run(2);
        }
    }

    /// <summary>
    /// Assume this as a ADO.net or some other interface which perform some steps to fetch data from somewhere
    /// Default template is getting data from some local list (you can fill it through constrcutor)
    /// </summary>
    public abstract class DataAccessor
    {
        //Steps
        public abstract void Connect();
        public abstract void Select();
        public abstract void Process(int top);
        public abstract void Disconnect();

        //Template method

        public void Run(int top)
        {
            Connect();
            Select();
            Process(top);
            Disconnect();
        }
    }

    public class ConcreteClass_Categories : DataAccessor
    {
        private List<string> categories;
        public override void Connect()
        {
            categories = new List<string>();
        }

        public override void Select()
        {
            categories.Add("Red");
            categories.Add("Green");
            categories.Add("Blue");
            categories.Add("Yellow");
            categories.Add("Purple");
            categories.Add("White");
            categories.Add("Black");
        }

        public override void Process(int top)
        {
            Console.WriteLine("Categories--- Top item from list");
            Console.WriteLine(categories[categories.Count - 1]);
        }

        public override void Disconnect()
        {
            categories.Clear();
        }
    }

    public class ConcreteClass_Products : DataAccessor
    {
        private List<string> products;
        public override void Connect()
        {
            products = new List<string>();
        }
        public override void Select()
        {
            products.Add("Car");
            products.Add("Bike");
            products.Add("Boat");
            products.Add("Truck");
            products.Add("Moped");
            products.Add("Rollerskate");
            products.Add("Stroller");
        }
        public override void Process(int top)
        {
            Console.WriteLine("Products ---- Top item from list");
            Console.WriteLine(products[products.Count-1]);
        }
        public override void Disconnect()
        {
            products.Clear();
        }
    }

}
