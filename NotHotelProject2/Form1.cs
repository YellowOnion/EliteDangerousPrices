using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Project7.Parser;
using Project7.Model;
using Microsoft.EntityFrameworkCore;

namespace Project7.Main
{
    public partial class Form1 : Form
    {
        Game Game;
        Database Database = new Database();

        public Form1()
        {
            Game = new Game(Database);
            InitializeComponent();
            Game.BindPlayers(cbPlayers);
            Game.ListPlayers();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
                    var s1 = Parsers.testAll;
        }

        private void btnNewPlayer_Click(object sender, EventArgs e)
        {
            Game.NewPlayer(inNewPlayer.Text);
            inNewPlayer.Text = "";
            Game.ListPlayers();
        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            Database.NewDatabase();
        }

        private void cbPlayers_SelectedValueChanged(object sender, EventArgs e)
        {

                Game.CurrentPlayer = (Player)cbPlayers.SelectedItem;
                DrawPlayer();
        }

        private void DrawPlayer()
        {
            try
            {
                lblCredit.Text = Game.CurrentPlayer.Credit.ToString() + " Ƀ";
                lblStation.Text = Game.CurrentPlayer.Location.StationName;
                lblSystem.Text = Game.CurrentPlayer.Location.StarSystem.StarName;
            }
            catch (Exception _)
            { }
        }

        private void btnDeletePlayer_Click(object sender, EventArgs e)
        {
            Game.DeletePlayer();
        }
    }
}
