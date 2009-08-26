using ContactsClient.PersonDetails;
using System.Windows.Forms;

namespace ContactsClient.Tests
{
    internal class FakePersonDetailsView : IPersonDetailsView
    {
        private string _title, _forename, _surname, _birthdayDay, _birthdayMonth;
        public bool FormClosed;

        public void ShowForm(bool Modal)
        { }

        #region IPersonDetailsView Members

        public IPersonDetailsPresenter Presenter
        {
            get { return null; }
            set { }
        }

        public void DisplayView() { }

        public void ShowForm()
        { }

        public void HideForm() { }

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
