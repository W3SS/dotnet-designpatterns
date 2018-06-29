using MvcDesignPattern.Models;
using System.Collections.Generic;

namespace MvcDesignPattern.Core
{
    public interface IDataImporter
    {
        IErrorLogger ErrorLogger { get; set; }
        void Import(List<Customer> data);
    }
}
