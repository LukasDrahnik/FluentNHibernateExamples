using FluentNHibernateExamples.DataVisualization.SQLiteDatabase;
using FluentNHibernateExamples.DataVisualization.SQLiteDatabase.Entities;
using System;
using System.Linq;
using System.Windows.Forms;
using NHibernate.Linq;

namespace DataVisualization
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Init databases
            SQLite.InitializeDatabase("SQLite.db", "SQLite.db");

            using (var session = SQLite.OpenSession())
            {
                // Test data
                using (var transaction = session.BeginTransaction())
                {
                    var barginBasin = new Store { Name = "Bargin Basin" };

                    var potatoes = new Product { Name = "Potatoes", Price = 3.60 };
                    var fish = new Product { Name = "Fish", Price = 4.49 };

                    barginBasin.AddProducts(potatoes, fish);

                    session.SaveOrUpdate(barginBasin);

                    transaction.Commit();
                }

                 // Init dataGridViews
                using (var transaction = session.BeginTransaction())
                {
                    dataGridView1.DataSource = session.Query<Store>().ToList();
                }
            }
        }
    }
}
