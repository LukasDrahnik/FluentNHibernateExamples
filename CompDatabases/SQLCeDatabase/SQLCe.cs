using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernateExamples.CompDatabases.Mappings;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System.Data.SqlServerCe;
using System.IO;
using Freya.Nhib;

namespace FluentNHibernateExamples.CompDatabases.SQLCeDatabase
{
    public class SQLCe
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
                .Database(MsSqlCeConfiguration.Standard
                .ConnectionString(_connectionString))
                .Mappings(m => m.FluentMappings.AddFromNamespaceOf<StoreMap>())
                .ExposeConfiguration(BuildSchema)
                .BuildSessionFactory();
        }

        private static void BuildSchema(Configuration config)
        {
            if (!File.Exists(_dbFile))
            {
                using (var engine = new SqlCeEngine(_connectionString))
                {
                    engine.CreateDatabase();
                }
            }
            if (_schema)
            {                
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
