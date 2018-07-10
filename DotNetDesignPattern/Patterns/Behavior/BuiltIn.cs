using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetDesignPattern.Patterns.Behavior
{
    public class Location
    {
        public double Latitude { get; }
        public double Longitude { get; }

        public Location(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }

    public class LocationReporter : IObserver<Location>
    {
        private IDisposable _unsuscriber;

        public string Name { get; }

        public LocationReporter(string name)
        {
            Name = name;
        }

        public virtual void Subscribe(IObservable<Location> provider) =>_unsuscriber = provider?.Subscribe(this);

        public virtual void Unsubscribe() => _unsuscriber?.Dispose();

        public void OnCompleted()
        {
            Console.WriteLine("The Location Tracker has completed transmitting data to {0}.", Name);
            Unsubscribe();
        }

        public void OnError(Exception error) => Console.WriteLine("{0}: The location cannot be determined.", Name);

        public void OnNext(Location value) => Console.WriteLine("{2}: The current location is {0}, {1}", value.Latitude, value.Longitude, Name);
    }

    public class LocationUnknownException : Exception
    {
        public LocationUnknownException()
        {
        }
    }

    public class LocationTracker : IObservable<Location>
    {
        private List<IObserver<Location>> _observers = new List<IObserver<Location>>();

        public IDisposable Subscribe(IObserver<Location> observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
            }
            return new Unsubscriber(_observers, observer);
        }

        public void TrackLocation(Location loc)
        {
            _observers.ForEach(o =>
            {
                if (loc == null)
                {
                    o.OnError(new LocationUnknownException());
                }
                else
                {
                    o.OnNext(loc);
                }
            });
        }

        public void EndTransmission()
        {
            foreach (var o in _observers.ToArray())
            {
                if (_observers.Contains(o))
                {
                    o.OnCompleted();
                }
            }
            _observers.Clear();
        }

        private class Unsubscriber : IDisposable
        {
            private List<IObserver<Location>> _observers;
            private readonly IObserver<Location> _observer;

            public Unsubscriber(List<IObserver<Location>> observers, IObserver<Location> observer)
            {
                _observers = observers;
                _observer = observer;
            }

            public void Dispose()
            {
                if (_observers.Contains(_observer))
                {
                    _observers.Remove(_observer);
                }
            }
        }
    }
}
