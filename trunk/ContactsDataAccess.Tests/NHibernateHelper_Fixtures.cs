using NUnit.Framework;
using ContactsDataAccess;
using NHibernate;

namespace ContactsDataAccess.Tests
{
    [TestFixture]
    public class NHibernateHelper_Fixtures
    {
        [Test]
        public void NHibernateHelper_OpenSession_CreatesSession()
        {
            ISession session;

            session = NHibernateHelper.OpenSession();

            Assert.IsNotNull(session, "Session is NULL");
        }
    }
}
