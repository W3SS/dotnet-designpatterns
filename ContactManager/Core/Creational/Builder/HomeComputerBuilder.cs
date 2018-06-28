using ContactManager.Models;
using System.Collections.Generic;
using System.Linq;

namespace ContactManager.Core
{
    public class HomeComputerBuilder : IComputerBuilder
    {
        private Computer _computer;

        public HomeComputerBuilder()
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
                var query = db.ComputerParts.SingleOrDefault(p => p.UseType == "HOME" && p.Part == "CPU");
                _computer.Parts.Add(query);
            }
        }

        public void AddCabinet()
        {
            using (AppDbContext db = new AppDbContext())
            {
                var query = db.ComputerParts.SingleOrDefault(p => p.UseType == "HOME" && p.Part == "CABINET");
                _computer.Parts.Add(query);
            }
        }

        public void AddMouse()
        {
            using (AppDbContext db = new AppDbContext())
            {
                var query = db.ComputerParts.SingleOrDefault(p => p.UseType == "HOME" && p.Part == "MOUSE");
                _computer.Parts.Add(query);
            }
        }

        public void AddKeyboard()
        {
            using (AppDbContext db = new AppDbContext())
            {
                var query = db.ComputerParts.SingleOrDefault(p => p.UseType == "HOME" && p.Part == "KEYBOARD");
                _computer.Parts.Add(query);
            }
        }

        public void AddMonitor()
        {
            using (AppDbContext db = new AppDbContext())
            {
                var query = db.ComputerParts.SingleOrDefault(p => p.UseType == "HOME" && p.Part == "MONITOR");
                _computer.Parts.Add(query);
            }
        }

        public Computer GetComputer()
        {
            return _computer;
        }
    }
}
