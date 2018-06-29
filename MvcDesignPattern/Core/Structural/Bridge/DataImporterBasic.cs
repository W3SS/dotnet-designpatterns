using MvcDesignPattern.Models;
using System;
using System.Collections.Generic;

namespace MvcDesignPattern.Core
{
    public class DataImporterBasic : IDataImporter
    {
        public IErrorLogger ErrorLogger { get; set; }
        public void Import(List<Customer> data)
        {
            using (AppDbContext db = new AppDbContext())
            {
                try
                {
                    foreach (var item in data)
                    {
                        db.Customers.Add(item);
                    }
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    ErrorLogger.Log(ex.Message);
                }
            }
        }
    }
}
