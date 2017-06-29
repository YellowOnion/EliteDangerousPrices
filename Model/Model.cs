using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Project7.Model
{
    public class TraderContext : DbContext
    {
        public DbSet<StarSystem> StarSystems { get; set; }
        public DbSet<Station> Stations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Filename=..\..\NewGameState.db");
        }
    }

    public class StarSystem
    {
        public int StarSystemId { get; set; }
        public string Name { get; set; }

        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public List<Station> Stations { get; set; }


    }

    public class Station
    {
        public int StationId { get; set; }
        public StarSystem StarSystem { get; set; }
        public string Name { get; set; }

    }
}
