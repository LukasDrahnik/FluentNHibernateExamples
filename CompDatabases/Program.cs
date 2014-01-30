using FluentNHibernateExamples.CompDatabases.Entities;
using FluentNHibernateExamples.CompDatabases.FirebirdDatabase;
using FluentNHibernateExamples.CompDatabases.SQLCeDatabase;
using FluentNHibernateExamples.CompDatabases.SQLiteDatabase;
using Freya.Utils;
using System;


namespace FluentNHibernateExamples.CompDatabases
{
    class Program
    {
        private const int iterations = 100;

        static void Main()
        {
            // Init databases
            SQLite.InitializeDatabase("SQLite.db", "SQLite.db");
            SQLCe.InitializeDatabase("SQLCe.sdf", "Data Source=SQLCe.sdf");            
            Firebird.InitializeDatabase("Firebird.fdb", "Database=Firebird.fdb;User=SYSDBA;Password=masterkey;Dialect=3;Charset=UTF8;ServerType=1");

            // Testing - SQLite
            TimeSpan timeSQLite = StopwatchUtil.Time(() =>
            {
                using (var session = SQLite.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        for (int i = 0; i < iterations; i++)
                        {
                            var barginBasin = new Store { Name = "Bargin Basin" };

                            var potatoes = new Product { Name = "Potatoes", Price = 3.60 };
                            var fish = new Product { Name = "Fish", Price = 4.49 };

                            barginBasin.AddProducts(potatoes, fish);

                            session.SaveOrUpdate(barginBasin);
                        }
                        transaction.Commit();
                    }
                }
            });

            // Testing - SQLCe
            TimeSpan timeSQLCe = StopwatchUtil.Time(() =>
            {
                using (var session = SQLCe.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        for (int i = 0; i < iterations; i++)
                        {
                            var barginBasin = new Store { Name = "Bargin Basin" };

                            var potatoes = new Product { Name = "Potatoes", Price = 3.60 };
                            var fish = new Product { Name = "Fish", Price = 4.49 };

                            barginBasin.AddProducts(potatoes, fish);

                            session.SaveOrUpdate(barginBasin);
                        }
                        transaction.Commit();
                    }
                }
            });

            // Testing - Firebird
            TimeSpan timeFirebird = StopwatchUtil.Time(() =>
            {
                using (var session = Firebird.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        for (int i = 0; i < iterations; i++)
                        {
                            var barginBasin = new Store { Name = "Bargin Basin" };

                            var potatoes = new Product { Name = "Potatoes", Price = 3.60 };
                            var fish = new Product { Name = "Fish", Price = 4.49 };

                            barginBasin.AddProducts(potatoes, fish);

                            session.SaveOrUpdate(barginBasin);
                        }
                        transaction.Commit();
                    }
                }
            });

            Console.WriteLine("Firebird: {0}", timeFirebird);
            Console.WriteLine("SQLite: {0}", timeSQLite);
            Console.WriteLine("SQLCe: {0}", timeSQLCe);

            Console.ReadKey();
        }        
    }
}
