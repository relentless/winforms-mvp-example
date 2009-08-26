using NHibernate;
using NHibernate.Cfg;
using ContactsDomain.DomainObjects;

namespace ContactsDataAccess
{
    public static class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    Configuration config = new Configuration();
                    config.Configure();
                    config.AddAssembly(typeof(Person).Assembly);
                    _sessionFactory = config.BuildSessionFactory();
                }

                return _sessionFactory;
            }
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
