﻿using FluentNHibernateExamples.CompDatabases.SQLCeDatabase.Mappings;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System.IO;
using System.Data.SqlServerCe;

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
                .Mappings(m =>
                          m.FluentMappings.Add<EmployeeMap>())
                           .Mappings(m =>
                          m.FluentMappings.Add<LocationMap>())
                           .Mappings(m =>
                          m.FluentMappings.Add<ProductMap>())
                           .Mappings(m =>
                          m.FluentMappings.Add<StoreMap>())
                .ExposeConfiguration(BuildSchema)
                .BuildSessionFactory();
        }

        private static void BuildSchema(Configuration config)
        {
            if (_schema || !File.Exists(_dbFile))
            {
                using (var engine = new SqlCeEngine(_connectionString))
                {
                    engine.CreateDatabase();
                }
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
