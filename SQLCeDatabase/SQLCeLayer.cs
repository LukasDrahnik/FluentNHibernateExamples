using FluentNHibernateExamples.CompDatabases.SQLCeDatabase.Entities;

namespace FluentNHibernateExamples.CompDatabases.SQLCeDatabase
{
    public static class SQLCeLayer
    {
        public static void InitializeDatabase(string dbFile, string connectionString, bool schema = true, bool createFactory = true)
        {
            SQLCe.InitializeDatabase(dbFile, connectionString, schema, createFactory);
        }

        public static void AddProductsToStore(Store store, params Product[] products)
        {
            using (var session = SQLCe.OpenSession())
            {
                foreach (var product in products)
                {
                    store.AddProduct(product);
                }
            }
        }
    }
}
