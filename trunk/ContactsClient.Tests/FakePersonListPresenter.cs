using ContactsClient.PersonList;
using ContactsDomain.BusinessManagers;
using ContactsDomain.DomainObjects;

namespace ContactsClient.Tests
{
    public class FakePersonListPresenter : IPersonListPresenter
    {
        internal string ShowPersonForename { get; set; }
        internal string ShowPersonSurname { get; set; }
        internal short ShowPersonBirthdayDay { get; set; }
        internal short ShowPersonBirthdayMonth { get; set; }
        internal bool LoadPressed { get; set; }
        internal bool AddPressed { get; set; }
        internal bool DeletePressed { get; set; }
        internal bool ViewPressed { get; set; }
        internal bool EditPressed { get; set; }

        private void LoadButtonPressed()
        {
            LoadPressed = true;
        }

        private void AddButtonPressed()
        {
            AddPressed = true;
        }

        private void DeleteButtonPressed()
        {
            DeletePressed = true;
        }

        private void ViewButtonPressed()
        {
            ViewPressed = true;
        }

        private void EditButtonPressed()
        {
            EditPressed = true;
        }
    }
}
