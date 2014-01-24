using FluentNHibernateExamples.CompDatabases.SQLiteDatabase.Entities;

namespace FluentNHibernateExamples.CompDatabases.SQLiteDatabase
{
    public static class SQLiteLayer
    {
        public static void InitializeDatabase(string dbFile, string connectionString, bool schema = true, bool createFactory = true)
        {
            SQLite.InitializeDatabase(dbFile, connectionString, schema, createFactory);
        }

        public static void AddProductsToStore(Store store, params Product[] products)
        {
            using (var session = SQLite.OpenSession())
            {
                foreach (var product in products)
                {
                    store.AddProduct(product);
                }
            }
        }
    }
}
