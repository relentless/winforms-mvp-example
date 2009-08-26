using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using ContactsDomain.DomainObjects;

namespace ContactsDataAccess.Utils
{
    public static class SchemaGenerator
    {
        /// <summary>
        /// Generates the required schema in the project database
        /// </summary>
        public static void GenerateDatabaseSchema()
        {
            Configuration config = new Configuration();
            config.Configure();
            config.AddAssembly(typeof(PhoneNumber).Assembly);
            config.AddAssembly(typeof(Person).Assembly);
            
            SchemaExport exporter = new SchemaExport(config);
            exporter.Execute(false, true, false);
        }
    }
}
