using MvcDesignPattern.Models;
using System.Collections.Generic;
using System.Linq;

namespace MvcDesignPattern.Core
{
    public class DevelopmentComputerBuilder : IComputerBuilder
    {
        private readonly Computer _computer;

        public DevelopmentComputerBuilder()
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
                var query = db.ComputerParts.SingleOrDefault(p => p.UseType == "DEV" && p.Part == "CPU");
                _computer.Parts.Add(query);
            }
            return this;
        }

        public IComputerBuilder AddCabinet()
        {
            using (AppDbContext db = new AppDbContext())
            {
                var query = db.ComputerParts.SingleOrDefault(p => p.UseType == "DEV" && p.Part == "CABINET");
                _computer.Parts.Add(query);
            }
            return this;
        }

        public IComputerBuilder AddMouse()
        {
            using (AppDbContext db = new AppDbContext())
            {
                var query = db.ComputerParts.SingleOrDefault(p => p.UseType == "DEV" && p.Part == "MOUSE");
                _computer.Parts.Add(query);
            }
            return this;
        }

        public IComputerBuilder AddKeyboard()
        {
            using (AppDbContext db = new AppDbContext())
            {
                var query = db.ComputerParts.SingleOrDefault(p => p.UseType == "DEV" && p.Part == "KEYBOARD");
                _computer.Parts.Add(query);
            }
            return this;
        }

        public IComputerBuilder AddMonitor()
        {
            using (AppDbContext db = new AppDbContext())
            {
                var query = db.ComputerParts.SingleOrDefault(p => p.UseType == "DEV" && p.Part == "MONITOR");
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
