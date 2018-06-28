using ContactManager.Models;
using System.Collections.Generic;
using System.Linq;

namespace ContactManager.Core
{
    public class DevelopmentComputerBuilder : IComputerBuilder
    {
        private Computer _computer;

        public DevelopmentComputerBuilder()
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
                var query = db.ComputerParts.SingleOrDefault(p => p.UseType == "DEV" && p.Part == "CPU");
                _computer.Parts.Add(query);
            }
        }

        public void AddCabinet()
        {
            using (AppDbContext db = new AppDbContext())
            {
                var query = db.ComputerParts.SingleOrDefault(p => p.UseType == "DEV" && p.Part == "CABINET");
                _computer.Parts.Add(query);
            }
        }

        public void AddMouse()
        {
            using (AppDbContext db = new AppDbContext())
            {
                var query = db.ComputerParts.SingleOrDefault(p => p.UseType == "DEV" && p.Part == "MOUSE");
                _computer.Parts.Add(query);
            }
        }

        public void AddKeyboard()
        {
            using (AppDbContext db = new AppDbContext())
            {
                var query = db.ComputerParts.SingleOrDefault(p => p.UseType == "DEV" && p.Part == "KEYBOARD");
                _computer.Parts.Add(query);
            }
        }

        public void AddMonitor()
        {
            using (AppDbContext db = new AppDbContext())
            {
                var query = db.ComputerParts.SingleOrDefault(p => p.UseType == "DEV" && p.Part == "MONITOR");
                _computer.Parts.Add(query);
            }
        }

        public Computer GetComputer()
        {
            return _computer;
        }
    }
}
