using MvcDesignPattern.Models;
using System.Collections.Generic;
using System.Linq;

namespace MvcDesignPattern.Core
{
    public class OfficeComputerBuilder : IComputerBuilder
    {
        private readonly Computer _computer;

        public OfficeComputerBuilder()
        {
            _computer = new Computer
            {
                Parts = new List<ComputerPart>()
            };
        }

        public IComputerBuilder AddCPU()
        {
            using (AppDbContext db = new AppDbContext())
            {
                var query = db.ComputerParts.SingleOrDefault(p => p.UseType == "OFFICE" && p.Part == "CPU");
                _computer.Parts.Add(query);
            }
            return this;
        }

        public IComputerBuilder AddCabinet()
        {
            using (AppDbContext db = new AppDbContext())
            {
                var query = db.ComputerParts.SingleOrDefault(p => p.UseType == "OFFICE" && p.Part == "CABINET");
                _computer.Parts.Add(query);
            }
            return this;
        }

        public IComputerBuilder AddMouse()
        {
            using (AppDbContext db = new AppDbContext())
            {
                var query = db.ComputerParts.SingleOrDefault(p => p.UseType == "OFFICE" && p.Part == "MOUSE");
                _computer.Parts.Add(query);
            }
            return this;
        }

        public IComputerBuilder AddKeyboard()
        {
            using (AppDbContext db = new AppDbContext())
            {
                var query = db.ComputerParts.SingleOrDefault(p => p.UseType == "OFFICE" && p.Part == "KEYBOARD");
                _computer.Parts.Add(query);
            }
            return this;
        }

        public IComputerBuilder AddMonitor()
        {
            using (AppDbContext db = new AppDbContext())
            {
                var query = db.ComputerParts.SingleOrDefault(p => p.UseType == "OFFICE" && p.Part == "MONITOR");
                _computer.Parts.Add(query);
            }
            return this;
        }

        public Computer GetComputer()
        {
            return _computer;
        }
    }
}
