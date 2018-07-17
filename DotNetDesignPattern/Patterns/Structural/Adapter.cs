using System.Collections.Generic;

namespace DotNetDesignPattern.Patterns.Structural
{
    // 'Adaptee' class
    public class ThirdPartyEmployee
    {
        public List<string> GetEmployeeList() => new List<string>
            {
                "Tom",
                "Sam",
                "Jack",
                "Mary"
            };
    }

    // 'ITarget' interface
    public interface ITarget
    {
        List<string> GetEmployees();
    }

    // 'Adapter' class
    public class ClassEmployeeAdapter : ThirdPartyEmployee, ITarget
    {
        public List<string> GetEmployees() => GetEmployeeList();
    }

    // 'Adapter' object
    public class ObjectEmployeeAdapter : ITarget
    {
        private readonly ThirdPartyEmployee _adaptee;

        public ObjectEmployeeAdapter(ThirdPartyEmployee adaptee) => _adaptee = adaptee;

        public List<string> GetEmployees() => _adaptee.GetEmployeeList();
    }
}
