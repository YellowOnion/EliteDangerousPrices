using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Project7.Parser;
using Project7.Model;
using Microsoft.EntityFrameworkCore;

namespace Project7.Main
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var db = new TraderContext())
            {

                var sysout = Parsers.testTCSV(textBox1.Text, new Model.StarSystem());
                db.StarSystems.Add(sysout);
                var count = db.SaveChanges();
               
                
            }

        }
    }
}
