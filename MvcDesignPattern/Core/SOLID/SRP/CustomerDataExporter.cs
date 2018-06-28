using MvcDesignPattern.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MvcDesignPattern.Core
{
    public class CustomerDataExporter
    {
        public static string ExportToCsv(List<Customer> data)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in data)
            {
                sb.AppendFormat("{0},{1},{2},{3}",
                    item.CustomerId,
                    item.CompanyName,
                    item.ContactName,
                    item.Country);
                sb.AppendLine();
            }

            return sb.ToString();
        }

        public static string ExportToXml(List<Customer> data)
        {
            throw new NotImplementedException();
        }

        public static string ExportToPdf(List<Customer> data)
        {
            throw new NotImplementedException();
        }
    }
}
