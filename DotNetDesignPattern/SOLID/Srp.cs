using System;
using System.Collections.Generic;

namespace DotNetDesignPattern.SOLID.SRP
{
    public class Student
    {
        private readonly List<string> _entries = new List<string>();

        public void Add(string name) => _entries.Add(name);

        public void Remove(int index) => _entries.RemoveAt(index);

        // breaks single responsibility principle
        public void Log(string error) => Console.WriteLine(error);
    }

    // handle the responsibility
    public class Logger
    {
        public void Log(string error) => Console.WriteLine(error);
    }

    public class StudentWithLog
    {
        private readonly Student _student;
        private readonly Logger _logger;

        public StudentWithLog()
        {
            _student = new Student();
            _logger = new Logger();
        }

        public void Add(string name) => _student.Add(name);

        public void Remove(int index)
        {
            try
            {
                _student.Remove(index);
            }
            catch (Exception ex)
            {
                _student.Log(ex.ToString());
                _logger.Log(ex.ToString());
            }
        }
    }
}
