using ContactsClient.PersonDetails;
using System.Windows.Forms;

namespace ContactsClient.Tests
{
    public class FakePersonDetailsView : IPersonDetailsView
    {
        private string _title, _forename, _surname, _birthdayDay, _birthdayMonth;
        public bool FormClosed;
        internal bool FormShown { get; set; }

        #region IPersonDetailsView Members

        public IPersonDetailsPresenter Presenter
        {
            set { }
        }

        public void ShowForm(bool Modal)
        {
            FormShown = true;
        }

        public void ShowForm()
        { }

        public void CloseForm()
        {
            FormClosed = true;
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string Forename
        {
            get{ return _forename; }
            set{ _forename = value; }
        }

        public string Surname
        {
            get{ return _surname; }
            set{ _surname = value; }
        }

        public string BirthdayDay
        {
            get{ return _birthdayDay; }
            set{ _birthdayDay = value; }
        }

        public string BirthdayMonth
        {
            get{ return _birthdayMonth; }
            set{ _birthdayMonth = value; }
        }

        #endregion
    }
}
