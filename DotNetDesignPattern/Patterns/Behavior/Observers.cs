using System.Collections.Generic;

namespace DotNetDesignPattern.Patterns.Behavior
{
    public interface ISubject
    {
        void RegisterObserver(IObserver o);
        void RemoveObserver(IObserver o);
        void NotifyObservers();
    }

    public interface IObserver
    {
        void Update(float temp, float humidity, float pressure);
    }

    public interface IDisplay
    {
        void Display();
    }

    public class WeatherData : ISubject
    {
        private List<IObserver> _observers = new List<IObserver>();
        private float _temperature;
        private float _humidity;
        private float _pressure;


        public void NotifyObservers()
        {
            _observers.ForEach(o => o.Update(_temperature, _humidity, _pressure));
        }

        public void RegisterObserver(IObserver o)
        {
            if (!_observers.Contains(o))
            {
                _observers.Add(o); 
            }
        }

        public void RemoveObserver(IObserver o)
        {
            if (_observers.IndexOf(o) != -1)
            {
                _observers.Remove(o);
            }
        }

        public void SetMeasurements(float temp, float humi, float pres)
        {
            _temperature = temp;
            _humidity = humi;
            _pressure = pres;

            NotifyObservers();
        }
    }

    public class CurrentConditionDisplay : IObserver, IDisplay
    {
        private readonly ISubject _weatherData;
        private float _temperature;
        private float _humidity;

        public CurrentConditionDisplay(ISubject weatherData)
        {
            _weatherData = weatherData;
            _weatherData.RegisterObserver(this);
        }

        public void Display()
        {
            System.Console.WriteLine($"Current conditions: {_temperature}F degrees and {_humidity}% humidity");
        }

        public void Update(float temp, float humidity, float pressure)
        {
            _temperature = temp;
            _humidity = humidity;

            Display();
        }
    }
}
