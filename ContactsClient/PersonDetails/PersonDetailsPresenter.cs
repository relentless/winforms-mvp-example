using System;
using ContactsDomain.BusinessManagers;
using ContactsDomain.DomainObjects;

namespace ContactsClient.PersonDetails
{
    public sealed class PersonDetailsPresenter: IPersonDetailsPresenter
    {
        private enum ViewMode
        {
            View, Add, Edit
        }

        private readonly IPersonManager _manager;
        private IPersonDetailsView _view;
        private ViewMode _mode = ViewMode.Add;
        private Person _person;

        private IViewFactory _factory;

        public PersonDetailsPresenter(IViewFactory Factory, IPersonManager Manager)
        {
            _factory = Factory;
            _manager = Manager;
        }

        #region IPersonDetailsPresenter Members

        public void ShowView(bool Modal)
        {
            _view.ShowForm(Modal);
        }

        public void ViewClosed()
        {
            _view = null;
        }

        public void Start()
        {
            _view = _factory.DetailsView();
            _view.Presenter = this;
        }

        public void OkButtonPressed()
        {
            switch (_mode)
            {
                case ViewMode.Add:
                    AddPersonToManager();
                    CloseView();
                    break;
                case ViewMode.View:
                    CloseView();
                    break;
                case ViewMode.Edit:
                    EditPersonWithManager();
                    CloseView();
                    break;
            }

            //set back to default Add mode
            _mode = ViewMode.Add;
        }

        public void ShowPerson(Person person)
        {
            _mode = ViewMode.View;
            _view.Title = "View Person";
            _person = person;
            DisplayPerson();
        }

        public void EditPerson(Person person)
        {
            _mode = ViewMode.Edit;
            _view.Title = "Edit Person";
            _person = person;
            DisplayPerson();
        }

        #endregion


        private void DisplayPerson()
        {
            _view.Forename = _person.Forename;
            _view.Surname = _person.Surname;
            _view.BirthdayDay = _person.BirthdayDay.ToString();
            _view.BirthdayMonth = _person.BirthdayMonth.ToString();
        }

        private void AddPersonToManager()
        {
            Person p = new Person();
            p.Forename = _view.Forename;
            p.Surname = _view.Surname;
            p.BirthdayDay = Convert.ToInt16(_view.BirthdayDay);
            p.BirthdayMonth = Convert.ToInt16(_view.BirthdayMonth);

            _manager.AddPerson(p);
        }

        private void EditPersonWithManager()
        {
            _person.Forename = _view.Forename;
            _person.Surname = _view.Surname;
            _person.BirthdayDay = Convert.ToInt16(_view.BirthdayDay);
            _person.BirthdayMonth = Convert.ToInt16(_view.BirthdayMonth);

            _manager.UpdatePerson(_person);
        }

        private void CloseView()
        {
            _view.CloseForm();
        }
    }
}
