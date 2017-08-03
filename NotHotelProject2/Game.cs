using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project7.Model;
using Microsoft.EntityFrameworkCore;
using System.Windows.Forms;

namespace Project7.Main

{

    class Game
    {
        private Database Db;

        public Player CurrentPlayer;

        public Game(Database db)
        {
            Db = db;
        }

        /// <summary>
        /// Lists all Jumps in 12 Ly's Protect against CurrentPlayer not being selected.
        /// </summary>
        /// <returns></returns>

        public List<Tuple<StarSystem, double>> Jumps()
        {
            if (CurrentPlayer != null)
                return Db.GetJumps(CurrentPlayer.Location.StarSystem);
            else
                return new List<Tuple<StarSystem, double>>();
        }

        
        /// <summary>
        /// sets the current player
        /// </summary>
        public void SetCurrentPlayer(string name)
        {
            CurrentPlayer = Db.GetPlayer(name);
        }

        // Not yet implmented
        public void Buy() { }

        public void NewPlayer(string name)
        {
            CurrentPlayer = Db.NewPlayer(name);
        }

        public void DeletePlayer()
        {
            Db.DeletePlayer(CurrentPlayer);
        }
        public List<Player> ListPlayers()
        {
            return Db.ListPlayers();
        }

        /// <summary>
        /// Not sure how to handle this case yet
        /// </summary>
        public void JumpTo(StarSystem star)
        {
            throw new Exception();
        }


        public void JumpTo(Station station)
        {
            CurrentPlayer.Location = station;
            Db.Jump(CurrentPlayer);
        }

        public void NewDatabase()
        {
            Db.NewDatabase();
        }
    }
}
