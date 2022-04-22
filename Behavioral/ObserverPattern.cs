using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral
{

    /// <summary>
    /// This is kind of Subscriber/Observer - Publisher/Subject patters
    /// Whenever there is some change on publisher or subject it will notify all the subscribers/observers for the change
    /// We will take an example of WeatherStation/Subject/Publisher and NewsAgency/Observer
    /// Whenever there is a change in temperature, the weather station will notify all the newsagency
    /// </summary>
    class ObserverPattern
    {
        public void CallObserver()
        {
            WeatherStation weatherS1 = new WeatherStation("City - 1");
            WeatherStation weatherS2 = new WeatherStation("City - 2");

            NewsAgency newsA1 = new NewsAgency("Daily news");
            NewsAgency newsA2 = new NewsAgency("BBG news");
            NewsAgency newsA3 = new NewsAgency("Any news");

            weatherS1.Subscribe(newsA1);
            weatherS1.Subscribe(newsA3);

            weatherS2.Subscribe(newsA1);
            weatherS2.Subscribe(newsA2);

            weatherS1.Temperature = 23.4f;
            weatherS2.Temperature = 44.0f;

        }
    }

    /// <summary>
    /// This is subject.
    /// Observer will update its state when ever there is some change 
    /// </summary>
    interface ISubject
    {
        void Subscribe(IObserver obserevr);
        void UnSubscribe(IObserver obserevr);
        void Notify();
    }

    // this is abstract observer
    interface IObserver
    {
        void Update(ISubject subject);
    }


    /// <summary>
    /// This is Subject/Subscriber class
    /// This keeps the list of subscribers and notify all the subscribers for the change happening in this class.
    /// </summary>
    class WeatherStation : ISubject
    {
        private string name;
        float temp;
        public string Name { get { return name; } }
        public float Temperature
        {
            get { return temp; }
            set { this.temp = value;
                Notify();
            }
        }

        List<IObserver> subscribers_newsagencies;

        public WeatherStation(string weatherStationName)
        {
            name = weatherStationName;
            subscribers_newsagencies = new List<IObserver>();
        }

        public void Notify()
        {
            foreach(IObserver observer in subscribers_newsagencies)
            {
                observer.Update(this);
            }
        }

        public void Subscribe(IObserver obserevr)
        {
            if (!subscribers_newsagencies.Contains(obserevr))
            {
                subscribers_newsagencies.Add(obserevr);
            }
        }

        public void UnSubscribe(IObserver obserevr)
        {
            if(subscribers_newsagencies.Contains(obserevr))
            {
                subscribers_newsagencies.Remove(obserevr);
            }
        }
    }

    /// <summary>
    /// This is Concrete Observer
    /// </summary>
    class NewsAgency : IObserver
    {
        private string name;
        public string Name { get { return name; } }
        public NewsAgency(string newsAgencyName)
        {
            this.name = newsAgencyName;
        }
        public void Update(ISubject subject)
        {
            if(subject is WeatherStation weatherStation)
            {
                Console.WriteLine($"On {this.Name} Agency page -- Weather Information has been update for station {weatherStation.Name} and the Temp is {weatherStation.Temperature}");
            }
        }
    }
}
