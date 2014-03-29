using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernateExamples.DataCaching.SQLiteDatabase.Mappings;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System.IO;
using Freya.Nhib;

namespace FluentNHibernateExamples.DataCaching.SQLiteDatabase
{
    public class SQLite
    {
        private static ISessionFactory _sessionFactory;
        private static string _dbFile;
        private static string _connectionString;
        private static bool _schema;

        public static void InitializeDatabase(string dbFile, string connectionString, bool schema = true, bool createFactory = true)
        {
            _dbFile = dbFile;
            _connectionString = connectionString;
            _schema = schema;
            if (createFactory) InitializeSessionFactory();
        }

        private static void InitializeSessionFactory()
        {
            _sessionFactory = Fluently.Configure()
                .Database(SQLiteConfiguration.Standard
                    .UsingFile(_dbFile))
                .Mappings(m => m.FluentMappings.AddFromNamespaceOf<StoreMap>())
                .ExposeConfiguration(BuildSchema)
                .BuildSessionFactory();
        }

        private static void BuildSchema(Configuration config)
        {
            if (_schema)
            {
                if (File.Exists(_dbFile))
                    File.Delete(_dbFile);

                new SchemaExport(config)
                    .Create(false, true);
            }
        }

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                    InitializeSessionFactory();
                return _sessionFactory;
            }
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
