using System;
using System.Configuration;
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
            //creating database 
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString;
            CreateDatabase(connectionString);
            Console.WriteLine("Database Created sucessfully");

            //creating a object of customer
            Customer customer=new Customer
            {
                CustomerId = 1,
                FirstName = "Jalpesh",
                LastName = "Vadgama"
            };

            //saving customer in database.
            using(ISession session = _sessionFactory.OpenSession())
                session.Save(customer);

            Console.WriteLine("Customer Saved");

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
