using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;



namespace FluentNhibernateCodeFirst
{
    class Program
    {
        private static ISessionFactory _sessionFactory;

        static void Main(string[] args)
        {

        }

        static void CreateDatabase(string connectionString)
        {
            var configuration = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connectionString).ShowSql)
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<CustomerMap>())
                .BuildConfiguration();

            var exporter = new SchemaExport(configuration);   
            exporter.Execute(true, true, false);

            _sessionFactory = configuration.BuildSessionFactory();  
        }
    }

    
}
