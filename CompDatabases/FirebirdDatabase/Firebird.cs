using FirebirdSql.Data.FirebirdClient;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernateExamples.CompDatabases.FirebirdDatabase.Mappings;
using Freya.Nhib;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System.IO;

namespace FluentNHibernateExamples.CompDatabases.FirebirdDatabase
{
    public class Firebird
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
            if (File.Exists(_dbFile))
                File.Delete(_dbFile);

            FbConnection.CreateDatabase(_connectionString);

            FirebirdConfiguration cfg = new FirebirdConfiguration()
                .ConnectionString(_connectionString)
                .AdoNetBatchSize(100);

            _sessionFactory = Fluently.Configure()
                .Database(cfg)
                .Mappings(m => m.FluentMappings.AddFromNamespaceOf<StoreMap>())
                .ExposeConfiguration(BuildSchema)
                .BuildConfiguration()
                .BuildSessionFactory();
        }

        private static void BuildSchema(Configuration config)
        {
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
