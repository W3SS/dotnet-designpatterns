using ContactManager.Models;
using System.Collections.Generic;
using System.Linq;

namespace ContactManager.Core
{
    public class OfficeComputerBuilder : IComputerBuilder
    {
        private Computer _computer;

        public OfficeComputerBuilder()
        {
            _computer = new Computer
            {
                Parts = new List<ComputerPart>()
            };
        }

        public void AddCPU()
        {
            using (AppDbContext db = new AppDbContext())
            {
                var query = db.ComputerParts.SingleOrDefault(p => p.UseType == "OFFICE" && p.Part == "CPU");
                _computer.Parts.Add(query);
            }
        }

        public void AddCabinet()
        {
            using (AppDbContext db = new AppDbContext())
            {
                var query = db.ComputerParts.SingleOrDefault(p => p.UseType == "OFFICE" && p.Part == "CABINET");
                _computer.Parts.Add(query);
            }
        }

        public void AddMouse()
        {
            using (AppDbContext db = new AppDbContext())
            {
                var query = db.ComputerParts.SingleOrDefault(p => p.UseType == "OFFICE" && p.Part == "MOUSE");
                _computer.Parts.Add(query);
            }
        }

        public void AddKeyboard()
        {
            using (AppDbContext db = new AppDbContext())
            {
                var query = db.ComputerParts.SingleOrDefault(p => p.UseType == "OFFICE" && p.Part == "KEYBOARD");
                _computer.Parts.Add(query);
            }
        }

        public void AddMonitor()
        {
            using (AppDbContext db = new AppDbContext())
            {
                var query = db.ComputerParts.SingleOrDefault(p => p.UseType == "OFFICE" && p.Part == "MONITOR");
                _computer.Parts.Add(query);
            }
        }

        public Computer GetComputer()
        {
            return _computer;
        }
    }
}
