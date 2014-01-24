using System;
using FluentNHibernateExamples.CompDatabases.SQLiteDatabase;
using FluentNHibernateExamples.CompDatabases.SQLCeDatabase;


namespace FluentNHibernateExamples.CompDatabases
{
    class Program
    {
        static void Main()
        {
            // Inicializace databáze
            SQLiteLayer.InitializeDatabase("SQLite.db", "SQLite.db");
            SQLCeLayer.InitializeDatabase("SQLCe.sdf", "Data Source=SQLCe.sdf");

            // Testovací data
            //var barginBasin = new Store { Name = "Bargin Basin" };
            //var potatoes = new Product { Name = "Potatoes", Price = 3.60 };
            //var fish = new Product { Name = "Fish", Price = 4.49 };

            //SQLiteLayer.AddProductsToStore(barginBasin, potatoes, fish);
           
            Console.ReadKey();
        }

        //private static ISessionFactory CreateSessionFactory(string _dbFile)
        //{
        //    return Fluently.Configure()
        //        .Database(SQLiteConfiguration.Standard
        //            .UsingFile(_dbFile))
        //        .Mappings(m =>
        //            m.FluentMappings.AddFromAssemblyOf<Program>())
        //        .ExposeConfiguration(Schema.Build(true))
        //        .BuildSessionFactory();
        //}

        //private static void BuildSchema(Configuration config)
        //{
        //    // delete the existing db on each run
        //    if (File.Exists(DbFile))
        //        File.Delete(DbFile);

        //    // this NHibernate tool takes a configuration (with mapping info in)
        //    // and exports a database schema from it
        //    new SchemaExport(config)
        //        .Create(false, true);
        //}

        //private static void WriteStorePretty(Examples.FirstProject.Database1.Entities.Store store)
        //{
        //    Console.WriteLine(store.Name);
        //    Console.WriteLine("  Products:");
                        
        //    foreach (var product in store.Products)
        //    {
        //        Console.WriteLine("    " + product.Name);
        //    }

        //    Console.WriteLine("  Staff:");

        //    foreach (var employee in store.Staff)
        //    {
        //        Console.WriteLine("    " + employee.FirstName + " " + employee.LastName);
        //    }

        //    Console.WriteLine();
        //}

        //public static void AddProductsToStore(Examples.FirstProject.Database1.Entities.Store store, params Examples.FirstProject.Database1.Entities.Product[] products)
        //{
        //    foreach (var product in products)
        //    {
        //        store.AddProduct(product);
        //    }
        //}

        //public static void AddEmployeesToStore(Examples.FirstProject.Database1.Entities.Store store, params Examples.FirstProject.Database1.Entities.Employee[] employees)
        //{
        //    foreach (var employee in employees)
        //    {
        //        store.AddEmployee(employee);
        //    }
        //}
    }
}
