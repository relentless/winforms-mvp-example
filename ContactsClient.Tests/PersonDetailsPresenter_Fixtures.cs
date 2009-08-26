//using NUnit.Framework;
//using ContactsClient.PersonDetails;
//using System.Collections.Generic;
//using ContactsDomain.DomainObjects;
//using ContactsDomain.BusinessManagers;
//using System;
//using ContactsDomain.Tests;

//namespace ContactsClient.Tests
//{
//    [TestFixture]
//    public class PersonDetailsPresenter_Fixtures
//    {
//        [Test]
//        public void PersonDetailsPresenter_OkButtonPressedInViewMode_ClosesView()
//        {
//            // Arrange
//            FakePersonManager manager = new FakePersonManager();
//            FakePersonDetailsView view = new FakePersonDetailsView();
//            IPersonDetailsPresenter presenter = new PersonDetailsPresenter(manager);
//            presenter.View = view;
//            presenter.ShowPerson(PersonObjectMother.GetPerson(TestPeople.Ted)); // sets to view mode

//            //Act
//            presenter.OkButtonPressed();

//            //Assert
//            Assert.IsTrue(view.FormClosed, "Form not closed");
//        }

//        [Test]
//        public void PersonDetailsPresenter_OkButtonPressedInAddMode_AddsPersonToRepository()
//        {
//            // Arrange
//            FakePersonManager manager = new FakePersonManager();

//            FakePersonDetailsView view = new FakePersonDetailsView() { Forename = "Jed", Surname = "Jetson", BirthdayDay = "29", BirthdayMonth = "2" };

//            IPersonDetailsPresenter presenter = new PersonDetailsPresenter(manager);
//            presenter.View = view;

//            //Act
//            presenter.OkButtonPressed();

//            //Assert
//            Person addedPerson = manager.AddedPerson;
//            Assert.IsNotNull(addedPerson, "The person was not added to the repository");
//            Assert.AreEqual("Jed", addedPerson.Forename, "Forename not added correctly");
//            Assert.AreEqual("Jetson", addedPerson.Surname, "Surname not added correctly");
//            Assert.AreEqual(29, addedPerson.BirthdayDay, "BirthdayDay not added correctly");
//            Assert.AreEqual(2, addedPerson.BirthdayMonth, "BirthdayMonth not added correctly");
//        }

//        [Test]
//        public void PersonDetailsPresenter_OkButtonPressedInAddMode_ClosesView()
//        {
//            // Arrange
//            FakePersonManager manager = new FakePersonManager();
//            FakePersonDetailsView view = new FakePersonDetailsView() { Forename = "Jed", Surname = "Jetson", BirthdayDay = "29", BirthdayMonth = "2" };
//            IPersonDetailsPresenter presenter = new PersonDetailsPresenter(manager);
//            presenter.View = view;

//            //Act
//            presenter.OkButtonPressed();

//            //Assert
//            Assert.IsTrue(view.FormClosed, "Form not closed");
//        }

//        [Test]
//        public void PersonDetailsPresenter_ShowPerson_SetsViewTitle()
//        {
//            // Arrange
//            FakePersonManager manager = new FakePersonManager();
//            FakePersonDetailsView view = new FakePersonDetailsView();
//            IPersonDetailsPresenter presenter = new PersonDetailsPresenter(manager);
//            presenter.View = view;

//            Person p = new Person();

//            //Act
//            presenter.ShowPerson(p);

//            //Assert
//            Assert.AreEqual("View Person", view.Title, "Title not set in view");
//        }

//        [Test]
//        public void PersonDetailsPresenter_ShowPerson_PassesCorrectDetailsToView()
//        {
//            // Arrange
//            FakePersonManager manager = new FakePersonManager();
//            FakePersonDetailsView view = new FakePersonDetailsView();
//            IPersonDetailsPresenter presenter = new PersonDetailsPresenter(manager);
//            presenter.View = view;

//            Person p = new Person(){Forename = "Jed", Surname = "Jetson", BirthdayDay = 29, BirthdayMonth = 2 };

//            //Act
//            presenter.ShowPerson(p);

//            //Assert
//            Assert.AreEqual("Jed", view.Forename, "Forename not set in view");
//            Assert.AreEqual("Jetson", view.Surname, "Surname not set in view");
//            Assert.AreEqual("29", view.BirthdayDay, "BirthdayDay not set in view");
//            Assert.AreEqual("2", view.BirthdayMonth, "BirthdayMonth not set in view");
//        }

//        [Test]
//        public void PersonDetailsPresenter_EditPerson_SetsViewTitle()
//        {
//            // Arrange
//            FakePersonManager manager = new FakePersonManager();
//            FakePersonDetailsView view = new FakePersonDetailsView();
//            IPersonDetailsPresenter presenter = new PersonDetailsPresenter(manager);
//            presenter.View = view;

//            Person p = new Person();

//            //Act
//            presenter.EditPerson(p);

//            //Assert
//            Assert.AreEqual("Edit Person", view.Title, "Title not set in view");
//        }

//        [Test]
//        public void PersonDetailsPresenter_EditPerson_PassesCorrectDetailsToView()
//        {
//            // Arrange
//            FakePersonManager manager = new FakePersonManager();
//            FakePersonDetailsView view = new FakePersonDetailsView();
//            IPersonDetailsPresenter presenter = new PersonDetailsPresenter(manager);
//            presenter.View = view;

//            Person p = new Person() { Forename = "Jed", Surname = "Jetson", BirthdayDay = 29, BirthdayMonth = 2 };

//            //Act
//            presenter.EditPerson(p);

//            //Assert
//            Assert.AreEqual("Jed", view.Forename, "Forename not set in view");
//            Assert.AreEqual("Jetson", view.Surname, "Surname not set in view");
//            Assert.AreEqual("29", view.BirthdayDay, "BirthdayDay not set in view");
//            Assert.AreEqual("2", view.BirthdayMonth, "BirthdayMonth not set in view");
//        }

//        [Test]
//        public void PersonDetailsPresenter_OkButtonPressedInEditMode_UpdatesPersonInManager()
//        {
//            // Arrange
//            FakePersonManager manager = new FakePersonManager();

//            FakePersonDetailsView view = new FakePersonDetailsView() ;

//            IPersonDetailsPresenter presenter = new PersonDetailsPresenter(manager);
//            presenter.View = view;
//            Person p = PersonObjectMother.GetPerson(TestPeople.Sue);
//            presenter.EditPerson(p);

//            //Act
//            presenter.OkButtonPressed();

//            //Assert
//            Person updatedPerson = manager.UpdatedPerson;
//            Assert.IsNotNull(updatedPerson, "The person was not updated in the manager");
//            Assert.AreEqual(p.Forename, updatedPerson.Forename, "Forename not added correctly");
//            Assert.AreEqual(p.Surname, updatedPerson.Surname, "Surname not added correctly");
//            Assert.AreEqual(p.BirthdayDay, updatedPerson.BirthdayDay, "BirthdayDay not added correctly");
//            Assert.AreEqual(p.BirthdayMonth, updatedPerson.BirthdayMonth, "BirthdayMonth not added correctly");
//        }

//        [Test]
//        public void PersonDetailsPresenter_OkButtonPressedInEditMode_ClosesView()
//        {
//            // Arrange
//            FakePersonManager manager = new FakePersonManager();
//            FakePersonDetailsView view = new FakePersonDetailsView() { Forename = "Jed", Surname = "Jetson", BirthdayDay = "29", BirthdayMonth = "2" };
//            IPersonDetailsPresenter presenter = new PersonDetailsPresenter(manager);
//            presenter.View = view;

//            //Act
//            presenter.EditPerson(PersonObjectMother.GetPerson(TestPeople.Ted));
//            presenter.OkButtonPressed();

//            //Assert
//            Assert.IsTrue(view.FormClosed, "Form not closed");
//        }
//    }
//}