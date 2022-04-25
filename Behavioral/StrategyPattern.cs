using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral
{
    class StrategyPattern
    {
        public void CallStrategy()
        {
            SortedList sortedList = new SortedList();
            sortedList.Add("James");
            sortedList.Add("Steven");
            sortedList.Add("Mario");
            sortedList.Add("Manish");
            sortedList.Add("Junos");

            sortedList.SetStrategy(new MergeSort());
            sortedList.Sort();

            sortedList.SetStrategy(new QuickSort());
            sortedList.Sort();

            sortedList.SetStrategy(new InsertionSort());
            sortedList.Sort();
        }
    }

    interface ISortStrategy
    {
        void Sort(SortedList context);
    }

    class MergeSort : ISortStrategy
    {
        public void Sort(SortedList context)
        {
            //we can implement merge sort algorithm here
            context.list.Sort();
            Console.WriteLine("Merge Sort algo/strategy applied");
        }
    }

    class QuickSort : ISortStrategy
    {
        public void Sort(SortedList context)
        {
            //we can implement quick sort algorithm here
            context.list.Sort();
            Console.WriteLine("Quick Sort algo/strategy applied");
        }
    }
    class InsertionSort : ISortStrategy
    {
        public void Sort(SortedList context)
        {
            //we can implement Insertion sort here
            context.list.Sort();
            Console.WriteLine("Insertion Sort algo/strategy applied");
        }
    }

    /// <summary>
    /// Context
    /// it contains the strategy object and we can change the strategy through this class and algo/strategy will get executed
    /// </summary>
    class SortedList
    {
        public List<string> list = new List<string>();
        //setting default strategy and this can be changed from set strategy method
        ISortStrategy strategy = new QuickSort();

        public void Add(string name)
        {
            list.Add(name);
        }

        public void SetStrategy(ISortStrategy strategy)
        {
            this.strategy = strategy;
        }

        public void Sort()
        {
            strategy.Sort(this);
        }
    }

}
