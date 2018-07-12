using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Threading;

namespace DotNetDesignPattern.Patterns.Creational
{
    public sealed class SingletonThreadSafety
    {
        private static SingletonThreadSafety _instance = null;
        private static readonly object _padlock = new object();

        SingletonThreadSafety()
        {
        }

        public static SingletonThreadSafety Instance
        {
            get
            {
                lock (_padlock)
                {
                    if (_instance == null)
                    {
                        _instance = new SingletonThreadSafety();
                    }
                    return _instance;
                }
            }
        }
    }

    // Bad code! Do not use!
    public sealed class SingletonDoubleCheckLocking
    {
        private static SingletonDoubleCheckLocking _instance = null;
        private static readonly object _padlock = new object();

        SingletonDoubleCheckLocking()
        {
        }

        public static SingletonDoubleCheckLocking Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_padlock)
                    {
                        if (_instance == null)
                        {
                            _instance = new SingletonDoubleCheckLocking();
                        }
                    }
                }
                return _instance;
            }
        }
    }

    public sealed class SingletonEagerLoading
    {
        private SingletonEagerLoading()
        {
        }

        public static SingletonEagerLoading Instance { get; } = new SingletonEagerLoading();
    }

    public sealed class SingletonLazyLoading
    {
        private static readonly Lazy<SingletonLazyLoading> lazy = new Lazy<SingletonLazyLoading>(() => new SingletonLazyLoading());

        public static SingletonLazyLoading Instance { get { return lazy.Value; } }

        private SingletonLazyLoading()
        {
        }
    }

    public abstract class Singleton<T> where T : class
    {
        private static readonly Lazy<T> _instance = new Lazy<T>(() =>
        {
            // Get non-public constructors for T.
            var ctors = typeof(T).GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic);

            // If we can't find the right type of construcor, throw an exception.
            if (!ctors.Any(ci => ci.GetParameters().Length == 0))
            {
                throw new ConstructorNotFoundException("Non-public ctor() note found.");
            }

            // Get reference to default non-public constructor.
            var ctor = ctors.FirstOrDefault(ci => ci.GetParameters().Length == 0);

            // Invoke constructor and return resulting object.
            return ctor.Invoke(null) as T;
        }, LazyThreadSafetyMode.ExecutionAndPublication);

        public static T Instance
        {
            get
            {
                return _instance.Value;
            }
        }
    }

    [Serializable]
    internal class ConstructorNotFoundException : Exception
    {
        public ConstructorNotFoundException()
        {
        }

        public ConstructorNotFoundException(string message) : base(message)
        {
        }

        public ConstructorNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ConstructorNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

    public sealed class MySingleton : Singleton<MySingleton>
    {
        public int Count { get; set; } = 0;

        private MySingleton()
        {
            Count++;
        }
    }
}
