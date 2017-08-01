using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Project7.Model;
using Project7.Parser;
using Microsoft.EntityFrameworkCore;

namespace Project7.Main
{
    class Database
    {
        public List<Player> ListPlayers()
        {
            List<Player> players;
            using (var db = new TraderContext())
            {
                players = db.Players.ToList();
            }
            return players;
        }

        public List<Player> GetPlayers()
        {
            using (var db = new TraderContext())
            {
                return db.Players.ToList();
            }

        }

        public Player NewPlayer(string name)
        {
            using (var db = new TraderContext())
            {
                var star = db.StarSystems.Where(s => s.StarName == "SOL").Include(s => s.Stations).Single();
                var station = star.Stations.ToList().Where(s => s.StationName == "Titan City").Single();
                var player = new Player() { PName = name, Credit = 1000, Location = station };
                db.Players.Add(player);
                db.SaveChanges();

                return player;
            }
        }

        public void DeletePlayer(Player player)
        {
            using (var db = new TraderContext())
            {
                //var p = (Player)db.Players.Where(a => a.Name == player.Name).First();
                db.Players.Remove(player);
                db.SaveChanges();
            }
        }

        public void NewDatabase()
        {
            var folder = "..\\..\\Data\\";
            using (var db = new TraderContext())
            {

                var SysDict = new Dictionary<string, StarSystem>();
                //var StaDict = new Dictionary<string, Station>();

                foreach (string line in File.ReadLines(folder + "System.csv").Skip(1))
                {


                    var sysout = Parsers.runSystemCSVParser(line, new Model.StarSystem() { Stations = new List<Station>() });
                    var distance = Math.Abs(Math.Pow(sysout.X - 0, 2) + Math.Pow(sysout.Y - 0, 2) + Math.Pow(sysout.Z - 0, 2));
                    if (distance < 10000)
                    {
                        SysDict.Add(sysout.StarName, sysout);
                    }
                }


                var stations = Parsers.runPricesFileParser(folder + "TradeDangerous.prices", new System.Text.UTF8Encoding());

                foreach (var stationR in stations)
                {
                    var uniqueName = stationR.UniqueName.Split('/');
                    var systemName = uniqueName[0];
                    var stationName = uniqueName[1];

                    Console.WriteLine(systemName + ": " + stationName);
                    Model.StarSystem star;
                    if (SysDict.TryGetValue(systemName, out star))
                    {
                        var station = new Model.Station() { StationName = stationName, StarSystem = star, Commodities = stationR.commodities };

                        star.Stations.Add(station);
                    }
                }

                foreach (var star in SysDict.Values)
                {
                    foreach (var s in star.Stations.Select(a => a.StationName)) Console.Write(s + ": :");
                    Console.WriteLine();
                    db.StarSystems.Add(star);
                }

                var count = db.SaveChanges();

            }
        }

        public Player GetPlayer(string name)
        {
            using (var db = new TraderContext())
            {
                return db.Players.Where(player => player.PName == name).Single();
            }
        }
    }
}
