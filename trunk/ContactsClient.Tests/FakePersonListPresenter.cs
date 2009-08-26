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

        private IPersonListView _view;

        #region IPersonListPresenter Members

        public IPersonListView View
        {
            set
            {
                _view = value;
                RegisterViewEvents();
            }
        }

        public void Start()
        { }

        private void RegisterViewEvents()
        {
            _view.LoadButtonPressed += new ViewEvent(LoadButtonPressed);
            _view.AddButtonPressed += new ViewEvent(AddButtonPressed);
            _view.ViewButtonPressed += new ViewEvent(ViewButtonPressed);
            _view.EditButtonPressed += new ViewEvent(EditButtonPressed);
            _view.DeleteButtonPressed += new ViewEvent(DeleteButtonPressed);
        }

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

        #endregion
    }
}
