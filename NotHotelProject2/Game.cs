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

        public List<Player> PlayerList;

        public Game(Database db)
        {
            Db = db;
 
        }

        public void BindPlayers(ComboBox cbx)
        {
            cbx.DataSource = PlayerList;
            cbx.ValueMember = "Name";
            cbx.DisplayMember = "Name";
        }

        public void Jump() {

        }

        public void SetCurrentPlayer(string name)
        {
            CurrentPlayer = Db.GetPlayer(name);
        }

        public void Buy() { }

        public void NewPlayer(string name)
        {
            CurrentPlayer = Db.NewPlayer(name);
        }

        public void DeletePlayer()
        {
            Db.DeletePlayer(CurrentPlayer);
        }
        public void ListPlayers()
        {
            PlayerList = Db.ListPlayers();
        }
    }
}
