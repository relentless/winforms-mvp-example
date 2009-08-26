using ContactsClient.PersonDetails;
using ContactsDomain.BusinessManagers;
using ContactsDomain.DomainObjects;

namespace ContactsClient.Tests
{
    public class FakePersonDetailsPresenter : IPersonDetailsPresenter
    {
        private IPersonDetailsView _view;

        internal string ShowPersonForename { get; set; }
        internal string ShowPersonSurname { get; set; }
        internal short ShowPersonBirthdayDay { get; set; }
        internal short ShowPersonBirthdayMonth { get; set; }

        internal bool EditPersonCalled { get; set; }

        internal FakePersonDetailsPresenter(IPersonManager Manager)
        { }

        internal FakePersonDetailsPresenter() { }

        public void ShowView(bool Modal)
        { }

        #region IPersonDetailsPresenter Members

        public IPersonDetailsView View
        {
            set{ _view = value; }
        }

        public void Start()
        { }

        public void OkButtonPressed()
        { }

        public void ViewClosed() { }

        public void ShowPerson(Person person)
        {
            ShowPersonForename = person.Forename;
            ShowPersonSurname = person.Surname;
            ShowPersonBirthdayDay = person.BirthdayDay;
            ShowPersonBirthdayMonth = person.BirthdayMonth;
        }

        public void EditPerson(Person person)
        {
            EditPersonCalled = true;

            ShowPersonForename = person.Forename;
            ShowPersonSurname = person.Surname;
            ShowPersonBirthdayDay = person.BirthdayDay;
            ShowPersonBirthdayMonth = person.BirthdayMonth;
        }

        #endregion
    }
}
