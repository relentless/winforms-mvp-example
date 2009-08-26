using NUnit.Framework;
using ContactsDataAccess.Utils;

namespace ContactsDataAccess.Tests
{
    [TestFixture]
    public class SchemaGenerator_Fixtures
    {
        [Test]
        public void generates_database_schema()
        {
            SchemaGenerator.GenerateDatabaseSchema();

            // TODO: Check database is set up properly
        }
    }
}
