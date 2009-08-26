//using NUnit.Framework;
//using ContactsClient.PersonList;
//using System.Collections.Generic;
//using ContactsDomain.DomainObjects;
//using ContactsDomain.BusinessManagers;
//using TestUtils;
//using System.Windows.Forms;
//using ContactsClient.PersonDetails;
//using ContactsDomain.Tests;
//using System;

//namespace ContactsClient.Tests
//{
//    [TestFixture]
//    public class PersonListPresenter_Fixtures
//    {
//        [Test]
//        public void PersonListPresenter_LoadButtonPressed_SetsPersonList()
//        {
//            // Arrange
//            List<Person> personList = new List<Person>(){new Person() {Id=1, Forename="Jim"},
//                                                         new Person() {Id=2, Forename="Sue"}};

//            FakePersonManager manager = new FakePersonManager();
//            manager.PersonList = personList;

//            FakePersonListView view = new FakePersonListView();

//            IPersonListPresenter presenter = new PersonListPresenter(manager);
//            presenter.View = view;

//            //Act
//            view.PressLoadButton();

//            //Assert
//            Assert.AreEqual(personList, view.PersonList, "PersonList in View does not match that from the Manager");
//        }

//        [Test]
//        public void PersonListPresenter_LoadButtonPressed_ShowsWaitCursorWhileDataLoading()
//        {
//            // Arrange
//            List<Person> personList = new List<Person>(){new Person() {Id=1, Forename="Jim"},
//                                                         new Person() {Id=2, Forename="Sue"}};

//            FakePersonManager manager = new FakePersonManager();
//            manager.PersonList = personList;

//            FakePersonListView view = new FakePersonListView();

//            IPersonListPresenter presenter = new PersonListPresenter(manager);
//            presenter.View = view;

//            DateTime startTime = DateTime.Now;

//            //Act
//            view.PressLoadButton();

//            //Assert
//            Assert.Greater(view.WaitCursorSetTime, startTime, "Wait cursor not set after start time");
//            Assert.Greater(view.DefaultCursorSetTime, view.WaitCursorSetTime, "Default cursor not set after wait cursor set");
//        }

//        [Test]
//        public void PersonListPresenter_AddButtonPressed_ShowsPersonDetailsView()
//        {
//            // Arrange
//            FakePersonManager manager = new FakePersonManager();
//            FakePersonListView listView = new FakePersonListView();
//            IPersonListPresenter listPresenter = new PersonListPresenter(manager);
//            listPresenter.View = listView;

//            //Act
//            listView.PressAddButton();

//            //Assert
//            Assert.IsTrue(listView.OpenPersonDetailsScreenModelessCalled, "View was not opened");
//        }

//        [Test]
//        public void PersonListPresenter_AddButtonPressed_ReloadsPersonList()
//        {
//            // Arrange
//            List<Person> personList = new List<Person>() { PersonObjectMother.GetPerson(TestPeople.Sue),
//                                                           PersonObjectMother.GetPerson(TestPeople.Bill)};
//            FakePersonManager manager = new FakePersonManager();
//            manager.PersonList = personList;

//            FakePersonListView listView = new FakePersonListView();
//            IPersonListPresenter listPresenter = new PersonListPresenter(manager);
//            listPresenter.View = listView;

//            //Act
//            listView.PressAddButton();

//            //Assert
//            Assert.AreEqual(personList, listView.PersonList, "PersonList in View does not match that from the Manager");
//        }

//        [Test]
//        public void PersonListPresenter_DeleteButtonPressed_GetsSelectedPersonFromView()
//        {
//            // Arrange
//            FakePersonManager manager = new FakePersonManager();
//            FakePersonListView view = new FakePersonListView();
//            IPersonListPresenter presenter = new PersonListPresenter(manager);
//            presenter.View = view;

//            //Act
//            view.PressDeleteButton();

//            //Assert
//            Assert.IsTrue(view.GetSeletedListItemCalled, "GetSeletedListItem() not called");
//        }

//        [Test]
//        public void PersonListPresenter_DeleteButtonPressed_DeletesSelectedPersonFromRepository()
//        {
//            // Arrange
//            List<Person> personList = new List<Person>() { new Person() { Id = 1, Forename = "Jim" } };

//            FakePersonManager manager = new FakePersonManager();
//            FakePersonListView view = new FakePersonListView();
//            view.PersonList = personList;

//            IPersonListPresenter presenter = new PersonListPresenter(manager);
//            presenter.View = view;

//            //Act
//            view.PressDeleteButton();

//            //Assert
//            Assert.IsNotNull(manager.DeletedPerson, "Person not deleted from repository");
//            Assertions.AssertPeopleAreEqual(personList[0], manager.DeletedPerson);
//        }

//        [Test]
//        public void PersonListPresenter_ViewButtonPressed_ShowsPersonDetailsViewModal()
//        {
//            // Arrange
//            List<Person> personList = new List<Person>() { PersonObjectMother.GetPerson(TestPeople.Sue) };

//            FakePersonManager manager = new FakePersonManager();
//            FakePersonListView listView = new FakePersonListView();
//            listView.SetPersonList(personList);
//            IPersonListPresenter listPresenter = new PersonListPresenter(manager);
//            listPresenter.View = listView;

//            listView.OpenDetailsScreenReturnPresenter = new FakePersonDetailsPresenter(new FakePersonManager());

//            //Act
//            listView.PressViewButton();

//            //Assert
//            Assert.IsTrue(listView.OpenViewPersonCalled, "View was not opened Modally");
//        }

//        [Test]
//        public void PersonListPresenter_ViewButtonPressed_PassesCorrectPersonDetailsToPersonDetailsPresenter()
//        {
//            // Arrange
//            List<Person> personList = new List<Person>() { PersonObjectMother.GetPerson(TestPeople.Ted) };

//            FakePersonManager manager = new FakePersonManager();
//            FakePersonListView listView = new FakePersonListView();
//            listView.SetPersonList(personList);
//            IPersonListPresenter listPresenter = new PersonListPresenter(manager);
//            listPresenter.View = listView;

//            //Act
//            listView.PressViewButton();

//            //Assert
//            Assert.IsNotNull(listView.ViewPerson, "Person not set in view");
//            Assertions.AssertPeopleAreEqual(PersonObjectMother.GetPerson(TestPeople.Ted), listView.ViewPerson);
//        }

//        [Test]
//        public void PersonListPresenter_EditButtonPressed_ShowsPersonDetailsViewInEditMode()
//        {
//            // Arrange
//            List<Person> personList = new List<Person>() { PersonObjectMother.GetPerson(TestPeople.Sue) };
//            FakePersonListView listView = new FakePersonListView();
//            listView.SetPersonList(personList);

//            FakePersonDetailsPresenter detailsPresenter = new FakePersonDetailsPresenter();
//            PersonListPresenter listPresenter = new PersonListPresenter(new FakePersonManager());
//            listPresenter.View = listView;

//            listView.OpenDetailsScreenReturnPresenter = detailsPresenter;

//            //Act
//            listView.PressEditButton();

//            //Assert
//            Assert.IsTrue(listView.OpenPersonDetailsScreenModelessCalled, "View was not opened");
//            Assert.IsTrue(detailsPresenter.EditPersonCalled, "Edit not called on details presenter");
//        }

//        [Test]
//        public void PersonListPresenter_EditButtonPressed_PassesCorrectPersonDetailsToPersonDetailsPresenter()
//        {
//            // Arrange
//            Person addedPerson = PersonObjectMother.GetPerson(TestPeople.Sue);
//            List<Person> personList = new List<Person>() { addedPerson };
//            FakePersonListView listView = new FakePersonListView();
//            listView.SetPersonList(personList);

//            FakePersonDetailsPresenter detailsPresenter = new FakePersonDetailsPresenter();
//            PersonListPresenter listPresenter = new PersonListPresenter(new FakePersonManager());
//            listPresenter.View = listView;

//            listView.OpenDetailsScreenReturnPresenter = detailsPresenter;

//            //Act
//            listView.PressEditButton();

//            //Assert
//            Assert.AreEqual(addedPerson.Forename, detailsPresenter.ShowPersonForename, "Forename not added correctly");
//            Assert.AreEqual(addedPerson.Surname, detailsPresenter.ShowPersonSurname, "Surname not added correctly");
//            Assert.AreEqual(addedPerson.BirthdayDay, detailsPresenter.ShowPersonBirthdayDay, "BirthdayDay not added correctly");
//            Assert.AreEqual(addedPerson.BirthdayMonth, detailsPresenter.ShowPersonBirthdayMonth, "BirthdayMonth not added correctly");
//        }

//        [Test]
//        public void PersonListPresenter_ViewButtonPressed_GivesWarningIfNoPersonSelected()
//        {
//            // Arrange
//            FakePersonManager manager = new FakePersonManager();
//            FakePersonListView listView = new FakePersonListView();

//            IPersonListPresenter listPresenter = new PersonListPresenter(manager);
//            listPresenter.View = listView;

//            //Act
//            listView.PressViewButton();

//            //Assert
//            Assert.AreEqual("Please select a person to view", listView.WarningMessage, "Warning message not set correctly");
//        }

//        [Test]
//        public void PersonListPresenter_EditButtonPressed_GivesWarningIfNoPersonSelected()
//        {
//            // Arrange
//            FakePersonManager manager = new FakePersonManager();
//            FakePersonListView listView = new FakePersonListView();

//            IPersonListPresenter listPresenter = new PersonListPresenter(manager);
//            listPresenter.View = listView;

//            //Act
//            listView.PressEditButton();

//            //Assert
//            Assert.AreEqual("Please select a person to edit", listView.WarningMessage, "Warning message not set correctly");
//        }

//        [Test]
//        public void PersonListPresenter_DeleteButtonPressed_GivesWarningIfNoPersonSelected()
//        {
//            // Arrange
//            FakePersonManager manager = new FakePersonManager();
//            FakePersonListView listView = new FakePersonListView();

//            IPersonListPresenter listPresenter = new PersonListPresenter(manager);
//            listPresenter.View = listView;

//            //Act
//            listView.PressDeleteButton();

//            //Assert
//            Assert.AreEqual("Please select a person to delete", listView.WarningMessage, "Warning message not set correctly");
//        }
//    }
//}
