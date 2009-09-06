using System;
using NUnit.Framework;
using NUnit.Extensions.Forms;
using ContactsClient.PersonList;
using ContactsClient.PersonDetails;
using ContactsDomain.DomainObjects;
using System.Collections.Generic;
using ContactsDomain.Tests;
using System.Windows.Forms;

namespace ContactsClient.Tests
{
    [TestFixture]
    public class PersonListView_Fixtures
    {
        [Test]
        [Category("Event Tests")]
        public void PersonListView_LoadButtonPressed_FiresEvent()
        {
            // Arrange
            bool LoadButtonEventFired = false;
            PersonListView view = new PersonListView();
            view.LoadButtonPressed += new ViewEvent(delegate { LoadButtonEventFired = true; });
            view.Show();
            ButtonTester loadTester = new ButtonTester("btnLoad");

            //Act
            loadTester.Click();

            // Assert
            Assert.IsTrue(LoadButtonEventFired, "LoadButtonPressed doesn't fire event");

            // Cleanup
            view.Close();
        }

        [Test]
        [Category("Event Tests")]
        public void PersonListView_DeleteButtonPressed_FiresEvent()
        {
            // Arrange
            bool DeleteButtonEventFired = false;
            PersonListView view = new PersonListView();
            view.DeleteButtonPressed += new ViewEvent(delegate { DeleteButtonEventFired = true; });
            view.Show();
            ButtonTester loadTester = new ButtonTester("btnDelete");

            //Act
            loadTester.Click();

            // Assert
            Assert.IsTrue(DeleteButtonEventFired, "DeleteButtonPressed doesn't fire event");

            // Cleanup
            view.Close();
        }

        [Test]
        [Category("Event Tests")]
        public void PersonListView_EditButtonPressed_FiresEvent()
        {
            // Arrange
            bool EditButtonEventFired = false;
            PersonListView view = new PersonListView();
            view.EditButtonPressed += new ViewEvent(delegate { EditButtonEventFired = true; });
            view.Show();
            ButtonTester loadTester = new ButtonTester("btnEdit");

            //Act
            loadTester.Click();

            // Assert
            Assert.IsTrue(EditButtonEventFired, "EditButtonPressed doesn't fire event");

            // Cleanup
            view.Close();
        }

        [Test]
        [Category("Event Tests")]
        public void PersonListView_AddButtonPressed_FiresEvent()
        {
            // Arrange
            bool AddButtonEventFired = false;
            PersonListView view = new PersonListView();
            view.AddButtonPressed += new ViewEvent(delegate { AddButtonEventFired = true; });
            view.Show();
            ButtonTester loadTester = new ButtonTester("btnAdd");

            //Act
            loadTester.Click();

            // Assert
            Assert.IsTrue(AddButtonEventFired, "AddButtonPressed doesn't fire event");
            
            // Cleanup
            view.Close();
        }

        [Test]
        [Category("Event Tests")]
        public void PersonListView_ViewButtonPressed_FiresEvent()
        {
            // Arrange
            bool ViewButtonEventFired = false;
            PersonListView view = new PersonListView();
            view.ViewButtonPressed += new ViewEvent(delegate { ViewButtonEventFired = true; });
            view.Show();
            ButtonTester loadTester = new ButtonTester("btnView");

            //Act
            loadTester.Click();

            // Assert
            Assert.IsTrue(ViewButtonEventFired, "ViewButtonPressed doesn't fire event");

            // Cleanup
            view.Close();
        }

        [Test]
        [Category("UI Tests")]
        public void PersonListView_SetPersonList_DisplaysCorrectPeople()
        {
            // Arrange
            FakePersonListPresenter presenter = new FakePersonListPresenter();
            ClientServiceLocator.PersonListPresenter = presenter;
            PersonListView view = new PersonListView();

            List<Person> personList = new List<Person>();
            personList.Add(PersonObjectMother.GetPerson(TestPeople.Bill));
            personList.Add(PersonObjectMother.GetPerson(TestPeople.Ted));

            view.Show();
            ListBoxTester listTester = new ListBoxTester("lbxPeople");

            //Act
            view.SetPersonList(personList);

            // Assert
            Assert.AreEqual(2, listTester.Properties.Items.Count, "Incorretc number of people in ListBox");
            Assert.Contains(personList[0], listTester.Properties.Items, "Person 0 not found in list");
            Assert.Contains(personList[1], listTester.Properties.Items, "Person 1 not found in list");

            // Cleanup
            view.Close();
        }

        [Test]
        [Category("UI Tests")]
        public void PersonListView_GetSelectedListItems_ReturnsCorrectPerson()
        {
            // Arrange
            PersonListView view = new PersonListView();

            List<Person> personList = new List<Person>();
            personList.Add(PersonObjectMother.GetPerson(TestPeople.Bill));
            personList.Add(PersonObjectMother.GetPerson(TestPeople.Ted));
            personList.Add(PersonObjectMother.GetPerson(TestPeople.Sue));

            ListBoxTester listTester = new ListBoxTester("lbxPeople");

            //Act
            view.SetPersonList(personList);
            view.Show();

            // select second person in listbox
            listTester.SetSelected(1, true);

            // Assert
            Assert.AreEqual(personList[1], view.GetSelectedListItem(), "Correct person not returned");

            // Cleanup
            view.Close();
        }

        [Test]
        public void PersonListView_ShowWaitCursor_ShowsWaitCursor()
        {
            //Arrange 
            ClientServiceLocator.PersonListPresenter = new FakePersonListPresenter();
            PersonListView view = new PersonListView();
            view.Show();
            FormTester viewTest = new FormTester("PersonListView");

            // Act
            view.Cursor = Cursors.Cross; // ensure set to something else before test
            view.SetWaitCursor();

            // Assert
            Assert.AreEqual(Cursors.WaitCursor, viewTest.Properties.Cursor, "Wait cursor not shown");

            // Cleanup
            view.Close();
        }

        [Test]
        public void PersonListView_ShowDefaultCursor_ShowsDefaultCursor()
        {
            //Arrange 
            ClientServiceLocator.PersonListPresenter = new FakePersonListPresenter();
            PersonListView view = new PersonListView();
            view.Show();
            FormTester viewTest = new FormTester("PersonListView");

            // Act
            view.Cursor = Cursors.Cross; // ensure set to something else before test
            view.SetDefaultCursor();

            // Assert
            Assert.AreEqual(Cursors.Default, viewTest.Properties.Cursor, "Default cursor not shown");

            // Cleanup
            view.Close();
        }

        [Test]
        public void PersonListView_ShowWarning_ShowsMessageBoxWithCorrectTitleAndMessage()
        {
            // Arrange
            string title = string.Empty;
            string message = string.Empty;
            ClientServiceLocator.PersonListPresenter = new FakePersonListPresenter();
            PersonListView view = new PersonListView();

            MessageBoxTester messageTester = null;

            ModalFormTester messageBoxTester = new ModalFormTester();
            messageBoxTester.ExpectModal("Test Title", new ModalFormActivated(delegate { messageTester = new MessageBoxTester("Test Title");
                                                                                            title = messageTester.Title;
                                                                                            message = messageTester.Text;
                                                                                            messageTester.ClickOk();
                                                                                            }));
            // Act
            view.ShowWarning("Test Title", "Test Message");

            // Assert
            Assert.IsTrue(messageBoxTester.Verify(), "MessageBox not shown");
            Assert.AreEqual("Test Title", title, "Title not correct");
            Assert.AreEqual("Test Message", message, "Message not correct");
        }
    }
}
