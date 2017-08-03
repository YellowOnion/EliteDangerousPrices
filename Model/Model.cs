using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project7.Model
{
    public class TraderContext : DbContext
    {
        public DbSet<StarSystem> StarSystems { get; set; }

        public DbSet<Player> Players { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Filename=..\..\NewGameState.db");
        }
    }

    /// <summary>
    /// Stars have obiting stations, name, and locations in 3D space.
    /// </summary>

    public class StarSystem
    {
        [Key]
        public string StarName { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public virtual List<Station> Stations { get; set; }


    }

    public class Station
    {
        [Key]
        public int StationId { get; set; }
        public string StationName { get; set; }
        public StarSystem StarSystem { get; set; }

        public virtual List<Commodity> Commodities { get; set; }

    }

    public class Commodity
    {
        public int Id { get; set; }
        public string CName { get; set; }
        public int Buy { get; set; }
        public int Sell { get; set; }

        public int Stock { get; set; }
    }

    public class Player
    {

        [Key]
        public string PName { get; set; }

        public int Credit { get; set; }

        public Station Location { get; set; }

        public virtual List<Item> Cargo { get; set; }

    }

    public class Item
    {
        [Key]
        public string IName { get; set; }
        public int Units { get; set; }
    }
}
