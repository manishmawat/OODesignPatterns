using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * In Iterator pattern we need:
 * 1    AbstractIterator
 * 2    ConcreteIterator
 * 3.   AbstractCollection
 * 4.   ConcreteCollection
 * 
 * 
 * Why we need Iterator pattern
 * Iterator Pattern -- This allows sequential access of elements without exposing the inside logic.
 * Problem          -- We can use any collection and add objects in that and iteract through this as normal data structure, but what if we change the way to store objects in collection (from list to array or something else) and iterate on them, in this case we need to notify clients for this change.
 * Solution         -- We can hide this logic and give same benefits with iterator pattern.
 * 
 */

namespace DesignPatterns.Behavioral
{
    class IteratorPattern
    {
        public void CallIterator()
        {
            ConcreteCollection employees = new ConcreteCollection();
            employees.AddEmployee(new Employee("Manish", 1));
            employees.AddEmployee(new Employee("John", 2));
            employees.AddEmployee(new Employee("Steve", 3));
            employees.AddEmployee(new Employee("Marry", 4));

            var Iterator = employees.CreateIterator();

            Console.WriteLine(Iterator.isCompleted);
            Console.WriteLine(Iterator.Next().Name);
            Console.WriteLine(Iterator.First().Name);
            Console.WriteLine(Iterator.isCompleted);
            Console.WriteLine(Iterator.Next().Name);
            Console.WriteLine(Iterator.Next().Name);
            Console.WriteLine(Iterator.Next().Name);
            Console.WriteLine(Iterator.isCompleted);
        }
    }


    class Employee
    {
        public int ID { get; }
        public string Name { get; set; }
        public Employee(string Name, int id)
        {
            this.Name = Name;
            this.ID = id;
        }
    }

    interface AbstractIterator
    {
        Employee First();
        Employee Next();
        bool isCompleted { get; }
    }

    class ConcreteIterator : AbstractIterator
    {
        private ConcreteCollection collection;
        int current = 0;
        int step = 1;

        public ConcreteIterator(ConcreteCollection collection)
        {
            this.collection = collection;
        }
        public bool isCompleted { 
            get {
                return current >= collection.Count;
            } 
        }

        public Employee First()
        {
            //current = 0;
            return collection.GetEmployee(0);
        }

        public Employee Next()
        {
            //current
            if (!isCompleted)
            {
                return collection.GetEmployee(current++);
            }
            else
                return null;
            
        }
    }

    interface AbstractCollection
    {
        ConcreteIterator CreateIterator();
    }

    class ConcreteCollection : AbstractCollection
    {
        List<Employee> employees = new List<Employee>();
        public ConcreteIterator CreateIterator()
        {
            return new ConcreteIterator(this);
        }

        public int Count
        {
            get
            {
                return employees.Count;
            }
        }

        public void AddEmployee(Employee employee)
        {
            employees.Add(employee);
        }

        public Employee GetEmployee(int IndexPosition)
        {
            return employees[IndexPosition];
        }
    }



}
