using System;
using NUnit.Framework;
using ContactsClient;
using ContactsClient.PersonList;
using ContactsClient.PersonDetails;

namespace ContactsClient.Tests
{
    [TestFixture]
    public class Program_Fixtures
    {
        [Test]
        public void Program_SetupServiceLocator_SetsUpClientServiceLocator()
        {
            // Arrange
            ClientServiceLocator.PersonDetailsPresenter = null;
            ClientServiceLocator.PersonListPresenter = null;

            // Act
            //Program.Main();
            Program.SetupServiceLocator();

            // Assert
            Assert.IsNotNull(ClientServiceLocator.PersonListPresenter, "PersonListPresenter not set");
            Assert.IsNotNull(ClientServiceLocator.PersonDetailsPresenter, "PersonDetailsPresenter not set");
            Assert.IsInstanceOfType(typeof(PersonListPresenter), ClientServiceLocator.PersonListPresenter, "PersonListPresenter not correct type");
            Assert.IsInstanceOfType(typeof(PersonDetailsPresenter), ClientServiceLocator.PersonDetailsPresenter, "PersonDetailsPresenter not correct type");
        }
    }
}
