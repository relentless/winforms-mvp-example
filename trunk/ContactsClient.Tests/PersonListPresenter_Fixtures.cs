using NUnit.Framework;
using ContactsClient.PersonList;
using System.Collections.Generic;
using ContactsDomain.DomainObjects;
using ContactsDomain.BusinessManagers;
using TestUtils;
using System.Windows.Forms;
using ContactsClient.PersonDetails;
using ContactsDomain.Tests;
using System;

namespace ContactsClient.Tests
{
    [TestFixture]
    public class PersonListPresenter_Fixtures
    {
        [Test]
        public void PersonListPresenter_LoadButtonPressed_SetsPersonList()
        {
            // Arrange
            List<Person> personList = new List<Person>(){PersonObjectMother.GetPerson(TestPeople.Ted),
                                                         PersonObjectMother.GetPerson(TestPeople.Sue)};

            FakePersonManager manager = new FakePersonManager();
            manager.PersonList = personList;

            FakePersonListView view = new FakePersonListView();
            IPersonListPresenter presenter = new PersonListPresenter(view, manager);
            ClientServiceLocator.PersonDetailsPresenter = new FakePersonDetailsPresenter();

            //Act
            view.PressLoadButton();

            //Assert
            Assert.AreEqual(personList, view.PersonList, "PersonList in View does not match that from the Manager");
        }

        [Test]
        public void PersonListPresenter_LoadButtonPressed_ShowsWaitCursorWhileDataLoading()
        {
            // Arrange
            List<Person> personList = new List<Person>(){PersonObjectMother.GetPerson(TestPeople.Ted),
                                                         PersonObjectMother.GetPerson(TestPeople.Sue)};

            FakePersonManager manager = new FakePersonManager();
            manager.PersonList = personList;

            FakePersonListView view = new FakePersonListView();
            IPersonListPresenter presenter = new PersonListPresenter(view, manager);
            ClientServiceLocator.PersonDetailsPresenter = new FakePersonDetailsPresenter();

            DateTime startTime = DateTime.Now;

            //Act
            view.PressLoadButton();

            //Assert
            Assert.Greater(view.WaitCursorSetTime, startTime, "Wait cursor not set after start time");
            Assert.Greater(view.DefaultCursorSetTime, view.WaitCursorSetTime, "Default cursor not set after wait cursor set");
        }

        [Test]
        public void PersonListPresenter_AddButtonPressed_CallsShowView()
        {
            // Arrange
            FakePersonManager manager = new FakePersonManager();
            FakePersonListView listView = new FakePersonListView();
            IPersonListPresenter listPresenter = new PersonListPresenter(listView, manager);
            FakePersonDetailsPresenter detailsPresenter = new FakePersonDetailsPresenter();
            ClientServiceLocator.PersonDetailsPresenter = detailsPresenter;

            //Act
            listView.PressAddButton();

            //Assert
            Assert.IsTrue(detailsPresenter.ShowViewCalled, "Show not called on Presenter");
        }

        [Test]
        public void PersonListPresenter_AddButtonPressed_CallsAddPerson()
        {
            // Arrange
            FakePersonManager manager = new FakePersonManager();
            FakePersonListView listView = new FakePersonListView();
            IPersonListPresenter listPresenter = new PersonListPresenter(listView, manager);
            FakePersonDetailsPresenter detailsPresenter = new FakePersonDetailsPresenter();
            ClientServiceLocator.PersonDetailsPresenter = detailsPresenter;

            //Act
            listView.PressAddButton();

            //Assert
            Assert.IsTrue(detailsPresenter.AddPersonCalled, "Add not called on Presenter");
        }

        [Test]
        public void PersonListPresenter_AddButtonPressed_ReloadsPersonList()
        {
            // Arrange
            List<Person> personList = new List<Person>() { PersonObjectMother.GetPerson(TestPeople.Sue),
                                                           PersonObjectMother.GetPerson(TestPeople.Bill)};

            ClientServiceLocator.PersonDetailsPresenter = new FakePersonDetailsPresenter();

            FakePersonManager manager = new FakePersonManager();
            manager.PersonList = personList;

            FakePersonListView listView = new FakePersonListView();
            IPersonListPresenter listPresenter = new PersonListPresenter(listView, manager);
            ClientServiceLocator.PersonDetailsPresenter = new FakePersonDetailsPresenter();

            //Act
            listView.PressAddButton();

            //Assert
            Assert.AreEqual(personList, listView.PersonList, "PersonList in View does not match that from the Manager");
        }

        [Test]
        public void PersonListPresenter_DeleteButtonPressed_GetsSelectedPersonFromView()
        {
            // Arrange
            FakePersonManager manager = new FakePersonManager();
            FakePersonListView view = new FakePersonListView();
            IPersonListPresenter presenter = new PersonListPresenter(view, manager);
            ClientServiceLocator.PersonDetailsPresenter = new FakePersonDetailsPresenter();

            //Act
            view.PressDeleteButton();

            //Assert
            Assert.IsTrue(view.GetSeletedListItemCalled, "GetSeletedListItem() not called");
        }

        [Test]
        public void PersonListPresenter_DeleteButtonPressed_DeletesSelectedPersonFromRepository()
        {
            // Arrange
            List<Person> personList = new List<Person>() { PersonObjectMother.GetPerson(TestPeople.Sue),
                                                           PersonObjectMother.GetPerson(TestPeople.Bill)};

            FakePersonManager manager = new FakePersonManager();
            FakePersonListView view = new FakePersonListView();
            view.PersonList = personList;

            IPersonListPresenter presenter = new PersonListPresenter(view, manager);
            ClientServiceLocator.PersonDetailsPresenter = new FakePersonDetailsPresenter();

            //Act
            view.PressDeleteButton();

            //Assert
            Assert.IsNotNull(manager.DeletedPerson, "Person not deleted from repository");
            Assertions.AssertPeopleAreEqual(personList[0], manager.DeletedPerson);
        }

        [Test]
        public void PersonListPresenter_ViewButtonPressed_CallsShowView()
        {
            // Arrange
            FakePersonManager manager = new FakePersonManager();
            FakePersonListView listView = new FakePersonListView();
            listView.PersonList = new List<Person>() {PersonObjectMother.GetPerson(TestPeople.Bill)};
            IPersonListPresenter listPresenter = new PersonListPresenter(listView, manager);
            FakePersonDetailsPresenter detailsPresenter = new FakePersonDetailsPresenter();
            ClientServiceLocator.PersonDetailsPresenter = detailsPresenter;

            //Act
            listView.PressViewButton();

            //Assert
            Assert.IsTrue(detailsPresenter.ShowViewCalled, "Show not called on Presenter");
        }

        [Test]
        public void PersonListPresenter_ViewButtonPressed_PassesDetailsToPersonDetailsPresenter()
        {
            // Arrange
            List<Person> personList = new List<Person>() { PersonObjectMother.GetPerson(TestPeople.Ted) };

            FakePersonManager manager = new FakePersonManager();
            FakePersonListView listView = new FakePersonListView();
            listView.SetPersonList(personList);
            IPersonListPresenter listPresenter = new PersonListPresenter(listView, manager);
            FakePersonDetailsPresenter detailsPresenter = new FakePersonDetailsPresenter();
            ClientServiceLocator.PersonDetailsPresenter = detailsPresenter;

            //Act
            listView.PressViewButton();

            //Assert
            Assertions.AssertPeopleAreEqual(PersonObjectMother.GetPerson(TestPeople.Ted), detailsPresenter.ShownPerson);
        }

        [Test]
        public void PersonListPresenter_EditButtonPressed_CallsShowView()
        {
            // Arrange
            FakePersonManager manager = new FakePersonManager();
            FakePersonListView listView = new FakePersonListView();
            listView.PersonList = new List<Person>() { PersonObjectMother.GetPerson(TestPeople.Bill) };
            IPersonListPresenter listPresenter = new PersonListPresenter(listView, manager);
            FakePersonDetailsPresenter detailsPresenter = new FakePersonDetailsPresenter();
            ClientServiceLocator.PersonDetailsPresenter = detailsPresenter;

            //Act
            listView.PressEditButton();

            //Assert
            Assert.IsTrue(detailsPresenter.ShowViewCalled, "Show not called on Presenter");
        }

        [Test]
        public void PersonListPresenter_EditButtonPressed_PassesDetailsToPersonDetailsPresenter()
        {
            // Arrange
            List<Person> personList = new List<Person>() { PersonObjectMother.GetPerson(TestPeople.Ted) };

            FakePersonManager manager = new FakePersonManager();
            FakePersonListView listView = new FakePersonListView();
            listView.SetPersonList(personList);
            IPersonListPresenter listPresenter = new PersonListPresenter(listView, manager);
            FakePersonDetailsPresenter detailsPresenter = new FakePersonDetailsPresenter();
            ClientServiceLocator.PersonDetailsPresenter = detailsPresenter;

            //Act
            listView.PressEditButton();

            //Assert
            Assertions.AssertPeopleAreEqual(PersonObjectMother.GetPerson(TestPeople.Ted), detailsPresenter.EditedPerson);
        }

        [Test]
        public void PersonListPresenter_ViewButtonPressed_GivesWarningIfNoPersonSelected()
        {
            // Arrange
            FakePersonManager manager = new FakePersonManager();
            FakePersonListView listView = new FakePersonListView();

            IPersonListPresenter listPresenter = new PersonListPresenter(listView, manager);
            ClientServiceLocator.PersonDetailsPresenter = new FakePersonDetailsPresenter();

            //Act
            listView.PressViewButton();

            //Assert
            Assert.AreEqual("Please select a person to view", listView.WarningMessage, "Warning message not set correctly");
        }

        [Test]
        public void PersonListPresenter_EditButtonPressed_GivesWarningIfNoPersonSelected()
        {
            // Arrange
            FakePersonManager manager = new FakePersonManager();
            FakePersonListView listView = new FakePersonListView();

            IPersonListPresenter listPresenter = new PersonListPresenter(listView, manager);
            ClientServiceLocator.PersonDetailsPresenter = new FakePersonDetailsPresenter();

            //Act
            listView.PressEditButton();

            //Assert
            Assert.AreEqual("Please select a person to edit", listView.WarningMessage, "Warning message not set correctly");
        }

        [Test]
        public void PersonListPresenter_DeleteButtonPressed_GivesWarningIfNoPersonSelected()
        {
            // Arrange
            FakePersonManager manager = new FakePersonManager();
            FakePersonListView listView = new FakePersonListView();

            IPersonListPresenter listPresenter = new PersonListPresenter(listView, manager);
            ClientServiceLocator.PersonDetailsPresenter = new FakePersonDetailsPresenter();

            //Act
            listView.PressDeleteButton();

            //Assert
            Assert.AreEqual("Please select a person to delete", listView.WarningMessage, "Warning message not set correctly");
        }
    }
}
