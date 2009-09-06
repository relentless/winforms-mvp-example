using ContactsClient.PersonDetails;
using ContactsDomain.BusinessManagers;
using ContactsDomain.DomainObjects;

namespace ContactsClient.Tests
{
    public class FakePersonDetailsPresenter : IPersonDetailsPresenter
    {
        internal Person ShownPerson { get; set; }
        internal Person EditedPerson { get; set; }

        internal bool AddPersonCalled { get; set; }
        internal bool ShowViewCalled { get; set; }

        public void ShowView(bool Modal)
        {
            ShowViewCalled = true;
        }

        #region IPersonDetailsPresenter Members

        public IPersonDetailsView View
        {
            get { return null; }
        }

        public void OkButtonPressed()
        { }

        public void AddPerson()
        {
            AddPersonCalled = true;
        }

        public void ShowPerson(Person person)
        {
            ShownPerson = person;
        }

        public void EditPerson(Person person)
        {
            EditedPerson = person;
        }

        #endregion
    }
}
