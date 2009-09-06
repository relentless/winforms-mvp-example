using NUnit.Framework;
using ContactsClient.PersonDetails;
using System.Collections.Generic;
using ContactsDomain.DomainObjects;
using ContactsDomain.BusinessManagers;
using System;
using ContactsDomain.Tests;
using TestUtils;

namespace ContactsClient.Tests
{
    [TestFixture]
    public class PersonDetailsPresenter_Fixtures
    {
        [Test]
        public void PersonDetailsPresenter_OkButtonPressedInViewMode_ClosesView()
        {
            // Arrange
            IPersonDetailsPresenter presenter = new PersonDetailsPresenter(new FakeViewFactory(), new FakePersonManager());
            presenter.ShowPerson(PersonObjectMother.GetPerson(TestPeople.Ted)); // sets to view mode

            //Act
            presenter.OkButtonPressed();

            //Assert
            FakePersonDetailsView view = (FakePersonDetailsView)presenter.View;
            Assert.IsTrue(view.FormClosed, "Form not closed");
        }

        [Test]
        public void PersonDetailsPresenter_OkButtonPressedInAddMode_ClosesView()
        {
            // Arrange
            IPersonDetailsPresenter presenter = new PersonDetailsPresenter(new FakeViewFactory(), new FakePersonManager());
            presenter.AddPerson();

            //Act
            presenter.OkButtonPressed();

            //Assert
            FakePersonDetailsView view = (FakePersonDetailsView)presenter.View;
            Assert.IsTrue(view.FormClosed, "Form not closed");
        }

        [Test]
        public void PersonDetailsPresenter_OkButtonPressedInEditMode_ClosesView()
        {
            // Arrange
            IPersonDetailsPresenter presenter = new PersonDetailsPresenter(new FakeViewFactory(), new FakePersonManager());
            presenter.EditPerson(PersonObjectMother.GetPerson(TestPeople.Ted)); // sets to edit mode

            //Act
            presenter.OkButtonPressed();

            //Assert
            FakePersonDetailsView view = (FakePersonDetailsView)presenter.View;
            Assert.IsTrue(view.FormClosed, "Form not closed");
        }

        [Test]
        public void PersonDetailsPresenter_OkButtonPressedInUndefinedMode_ThrowsException()
        {
            // Arrange
            IPersonDetailsPresenter presenter = new PersonDetailsPresenter(new FakeViewFactory(), new FakePersonManager());

            //Act
            ApplicationException expectedException = null;

            try{ presenter.OkButtonPressed(); }
            catch (ApplicationException ex){ expectedException = ex; }

            //Assert
            Assert.IsNotNull(expectedException, "Exception not thrown as expected");
        }

        [Test]
        public void PersonDetailsPresenter_OkButtonPressedInAddMode_AddsPersonToManager()
        {
            // Arrange
            FakePersonManager manager = new FakePersonManager();
            IPersonDetailsView view = new FakePersonDetailsView() { Forename = "Jed", Surname = "Jetson", BirthdayDay = "29", BirthdayMonth = "2" };
            FakeViewFactory factory = new FakeViewFactory(view);

            IPersonDetailsPresenter presenter = new PersonDetailsPresenter(factory, manager);
            presenter.AddPerson();

            //Act
            presenter.OkButtonPressed();

            //Assert
            Person addedPerson = manager.AddedPerson;
            Assert.IsNotNull(addedPerson, "The person was not added to the repository");
            Assert.AreEqual("Jed", addedPerson.Forename, "Forename not added correctly");
            Assert.AreEqual("Jetson", addedPerson.Surname, "Surname not added correctly");
            Assert.AreEqual(29, addedPerson.BirthdayDay, "BirthdayDay not added correctly");
            Assert.AreEqual(2, addedPerson.BirthdayMonth, "BirthdayMonth not added correctly");
        }

        [Test]
        public void PersonDetailsPresenter_OkButtonPressedInEditMode_UpdatesPersonInManager()
        {
            // Arrange
            FakePersonManager manager = new FakePersonManager();
            IPersonDetailsPresenter presenter = new PersonDetailsPresenter(new FakeViewFactory(), manager);

            Person p = PersonObjectMother.GetPerson(TestPeople.Sue);
            presenter.EditPerson(p);

            //Act
            presenter.OkButtonPressed();

            //Assert
            Person updatedPerson = manager.UpdatedPerson;
            Assert.IsNotNull(updatedPerson, "The person was not updated in the manager");

            Assertions.AssertPeopleAreEqual(p, updatedPerson);
        }

        [Test]
        public void PersonDetailsPresenter_ShowPerson_SetsViewTitle()
        {
            // Arrange
            FakePersonManager manager = new FakePersonManager();
            FakePersonDetailsView view = new FakePersonDetailsView();
            FakeViewFactory factory = new FakeViewFactory(view);
            IPersonDetailsPresenter presenter = new PersonDetailsPresenter(factory, manager);

            //Act
            presenter.ShowPerson(new Person());

            //Assert
            Assert.AreEqual("View Person", view.Title, "Title not set in view");
        }

        [Test]
        public void PersonDetailsPresenter_EditPerson_SetsViewTitle()
        {
            // Arrange
            FakePersonManager manager = new FakePersonManager();
            FakePersonDetailsView view = new FakePersonDetailsView();
            FakeViewFactory factory = new FakeViewFactory(view);
            IPersonDetailsPresenter presenter = new PersonDetailsPresenter(factory, manager);

            //Act
            presenter.EditPerson(new Person());

            //Assert
            Assert.AreEqual("Edit Person", view.Title, "Title not set in view");
        }

        [Test]
        public void PersonDetailsPresenter_AddPerson_SetsViewTitle()
        {
            // Arrange
            FakePersonManager manager = new FakePersonManager();
            FakePersonDetailsView view = new FakePersonDetailsView();
            FakeViewFactory factory = new FakeViewFactory(view);
            IPersonDetailsPresenter presenter = new PersonDetailsPresenter(factory, manager);

            //Act
            presenter.AddPerson();

            //Assert
            Assert.AreEqual("Add Person", view.Title, "Title not set in view");
        }

        [Test]
        public void PersonDetailsPresenter_ShowPerson_PassesCorrectDetailsToView()
        {
            // Arrange
            FakePersonManager manager = new FakePersonManager();
            FakePersonDetailsView view = new FakePersonDetailsView();
            FakeViewFactory factory = new FakeViewFactory(view);
            IPersonDetailsPresenter presenter = new PersonDetailsPresenter(factory, manager);

            //Act
            presenter.ShowPerson(PersonObjectMother.GetPerson(TestPeople.Bill));

            //Assert
            Assert.AreEqual(PersonObjectMother.GetPerson(TestPeople.Bill).Forename, view.Forename, "Forename not set in view");
            Assert.AreEqual(PersonObjectMother.GetPerson(TestPeople.Bill).Surname, view.Surname, "Surname not set in view");
            Assert.AreEqual(PersonObjectMother.GetPerson(TestPeople.Bill).BirthdayDay.ToString(), view.BirthdayDay, "BirthdayDay not set in view");
            Assert.AreEqual(PersonObjectMother.GetPerson(TestPeople.Bill).BirthdayMonth.ToString(), view.BirthdayMonth, "BirthdayMonth not set in view");
        }

        [Test]
        public void PersonDetailsPresenter_EditPerson_PassesCorrectDetailsToView()
        {
            // Arrange
            FakePersonManager manager = new FakePersonManager();
            FakePersonDetailsView view = new FakePersonDetailsView();
            FakeViewFactory factory = new FakeViewFactory(view);
            IPersonDetailsPresenter presenter = new PersonDetailsPresenter(factory, manager);

            //Act
            presenter.EditPerson(PersonObjectMother.GetPerson(TestPeople.Ted));

            //Assert
            Assert.AreEqual(PersonObjectMother.GetPerson(TestPeople.Ted).Forename, view.Forename, "Forename not set in view");
            Assert.AreEqual(PersonObjectMother.GetPerson(TestPeople.Ted).Surname, view.Surname, "Surname not set in view");
            Assert.AreEqual(PersonObjectMother.GetPerson(TestPeople.Ted).BirthdayDay.ToString(), view.BirthdayDay, "BirthdayDay not set in view");
            Assert.AreEqual(PersonObjectMother.GetPerson(TestPeople.Ted).BirthdayMonth.ToString(), view.BirthdayMonth, "BirthdayMonth not set in view");
        }

        [Test]
        public void PersonDetailsPresenter_ShowView_ShowsView()
        {
            // Arrange
            FakePersonManager manager = new FakePersonManager();
            FakePersonDetailsView view = new FakePersonDetailsView();
            FakeViewFactory factory = new FakeViewFactory(view);
            IPersonDetailsPresenter presenter = new PersonDetailsPresenter(factory, manager);

            //Act
            presenter.ShowView(false);

            //Assert
            Assert.IsTrue(view.FormShown, "View not shown");
        }
    }
}