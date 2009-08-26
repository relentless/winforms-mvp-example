using System;
using NUnit.Framework;
using ContactsClient.PersonDetails;
using ContactsClient.PersonList;

namespace ContactsClient.Tests
{
    [TestFixture]
    public class ClientServiceLocator_Fixtures
    {
        [Test]
        public void ClientServiceLocator_GetPersonDetailsPresenter_ReturnsCorrectObject()
        {
            //Arrange
            FakePersonDetailsPresenter presenter = new FakePersonDetailsPresenter(new FakePersonManager());

            //Act
            ClientServiceLocator.PersonDetailsPresenter = presenter;

            //Assert
            Assert.AreSame(presenter, ClientServiceLocator.PersonDetailsPresenter, "Presenter not set properly");
        }

        [Test]
        public void ClientServiceLocator_GetPersonDetailsPresenterWithNoPresenter_RaisesApplicationException()
        {
            //Arrange
            ApplicationException nre = null;
            ClientServiceLocator.PersonDetailsPresenter = null;

            //Act
            try
            {
                IPersonDetailsPresenter presenter = ClientServiceLocator.PersonDetailsPresenter;
            }
            catch (ApplicationException ex)
            {
                nre = ex;
            }

            //Assert
            Assert.IsNotNull(nre, "Exception not raised");
        }

        [Test]
        public void ClientServiceLocator_GetPersonListPresenter_ReturnsCorrectObject()
        {
            //Arrange
            FakePersonListPresenter presenter = new FakePersonListPresenter();

            //Act
            ClientServiceLocator.PersonListPresenter = presenter;

            //Assert
            Assert.AreSame(presenter, ClientServiceLocator.PersonListPresenter, "Presenter not set properly");
        }

        [Test]
        public void ClientServiceLocator_GetPersonListPresenterWithNoPresenter_RaisesApplicationException()
        {
            //Arrange
            ApplicationException nre = null;
            ClientServiceLocator.PersonListPresenter = null;

            //Act
            try
            {
                IPersonListPresenter presenter = ClientServiceLocator.PersonListPresenter;
            }
            catch (ApplicationException ex)
            {
                nre = ex;
            }

            //Assert
            Assert.IsNotNull(nre, "Exception not raised");
        }
    }
}
