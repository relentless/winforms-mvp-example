using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ContactsDomain.DomainObjects;
using ContactsClient;
using ContactsDomain.BusinessManagers;
using ContactsDataAccess.Repository;
using ContactsClient.PersonDetails;

namespace ContactsClient.PersonList
{
    public sealed partial class PersonListView : Form, IPersonListView
    {
        private IPersonListPresenter _presenter;

        public event ViewEvent LoadButtonPressed;
        public event ViewEvent AddButtonPressed;
        public event ViewEvent ViewButtonPressed;
        public event ViewEvent EditButtonPressed;
        public event ViewEvent DeleteButtonPressed;

        public PersonListView()
        {
            InitializeComponent();

            this.FormClosed += new FormClosedEventHandler(PersonListView_FormClosed);
        }

        void PersonListView_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        public void SetPersonList(List<Person> PersonList)
        {
            lbxPeople.DataSource = PersonList;
        }

        public IPersonListPresenter Presenter
        {
            set { _presenter = value; }
        }

        public Person GetSelectedListItem()
        {
            return (Person)lbxPeople.SelectedItem;
        }

        public void ShowView()
        {
            Show();
        }

        public void OpenPersonDetailsScreenViewPerson(Person person)
        {
            PersonDetailsView view = new PersonDetailsView();
            view.Forename = person.Forename;
            view.Surname = person.Surname;
            view.BirthdayDay = person.BirthdayDay.ToString();
            view.BirthdayMonth = person.BirthdayMonth.ToString();
            view.ShowDialog();
        }

        public void SetWaitCursor()
        {
            Cursor = Cursors.WaitCursor;
        }

        public void SetDefaultCursor()
        {
            Cursor = Cursors.Default;
        }

        public void ShowWarning(string Title, string Message)
        {
            MessageBox.Show(Message, Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (LoadButtonPressed != null)
                LoadButtonPressed.Invoke();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (AddButtonPressed != null)
                AddButtonPressed.Invoke();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DeleteButtonPressed != null)
                DeleteButtonPressed.Invoke();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (ViewButtonPressed != null)
                ViewButtonPressed.Invoke();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (EditButtonPressed != null)
                EditButtonPressed.Invoke();
        }
    }
}
