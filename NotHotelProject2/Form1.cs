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

        public Form1()
        {
            Game = new Game(Database);
            InitializeComponent();
            UpdatePlayers();
            button2.Visible = false; // for importing purposes, comment out.
        }

        private void UpdateJumps()
        {

            var stars = Game.Jumps();
            var items = new List<Tuple<string, object>>();

            foreach (var item in stars)
            {
                var star = item.Item1;
                items.Add(new Tuple<string, object>("☀ " + star.StarName + " - " + item.Item2.ToString("F") + " Ly", star));
                foreach (var station in star.Stations)
                {
                    items.Add(new Tuple<string, object>("    🏙 " + station.StationName, station));
                }
            }

            listJumps.DataSource = items;
            listJumps.DisplayMember = "Item1";
            listJumps.ValueMember = "Item2";
        }


        private void UpdatePlayers()
        {
            cbPlayers.Items.Clear();
            foreach (var player in Game.ListPlayers())
                cbPlayers.Items.Add(player.PName);
        }

        private void button2_Click(object sender, EventArgs e)
        {
                    var s1 = Parsers.testAll;
        }

        private void btnNewPlayer_Click(object sender, EventArgs e)
        {
            Game.NewPlayer(inNewPlayer.Text);
            inNewPlayer.Text = "";
            UpdatePlayers();
        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            Game.NewDatabase();
        }

        private void cbPlayers_SelectedValueChanged(object sender, EventArgs e)
        {

                Game.SetCurrentPlayer((string)cbPlayers.SelectedItem);
                DrawPlayer();
        }

        /// <summary>
        /// Draw the player data on the form, protect against currentplayer not being selected.
        /// </summary>

        private void DrawPlayer()
        {
            Player player = null;
            try
            {
                player = Game.CurrentPlayer;
            }
            catch (Exception _)
            { }
            if (player != null)
            { 
                lblCredit.Text = Game.CurrentPlayer.Credit.ToString() + " Cr";
                lblStation.Text = Game.CurrentPlayer.Location.StationName;
                lblSystem.Text = Game.CurrentPlayer.Location.StarSystem.StarName;
                UpdateJumps();
            }
        }

        private void btnDeletePlayer_Click(object sender, EventArgs e)
        {
            Game.DeletePlayer();
            UpdatePlayers();
            UpdateJumps();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            UpdateJumps();
        }

        private void btnJump_Click(object sender, EventArgs e)
        {
            try
            {
                Game.JumpTo((Station)listJumps.SelectedValue);
            }
            catch (Exception _)
            {
                try
                { Game.JumpTo((StarSystem)listJumps.SelectedValue); }
                catch
                {
                    MessageBox.Show("Jumping to stars not allowed!");
                }
            }

            UpdatePlayers();
            UpdateJumps();
        }
    }
}
