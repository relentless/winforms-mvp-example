using ContactsDomain.BusinessManagers;
using System.Collections.Generic;
using ContactsDomain.DomainObjects;
using ContactsClient.PersonDetails;
using ContactsDataAccess.Repository;
using System.Threading;

namespace ContactsClient.PersonList
{
    public sealed class PersonListPresenter: IPersonListPresenter
    {
        private IPersonListView _view;
        private readonly IPersonManager _manager;
        private List<Person> _personList;

        public PersonListPresenter(IPersonListView View, IPersonManager Manager)
        {
            _view = View;
            _manager = Manager;

            _view.Presenter = this;
            RegisterViewEvents();
            _view.ShowView();
        }

        //public void Start()
        //{
        //    _view.Presenter = this;
        //    RegisterViewEvents();
        //    _view.ShowView();
        //}

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
            LoadPersonList();
        }

        private void AddButtonPressed()
        {
            IPersonDetailsPresenter detailsPresenter = ClientServiceLocator.PersonDetailsPresenter;
            //detailsPresenter.Start();
            detailsPresenter.ShowView(true);
            detailsPresenter.AddPerson();
            LoadPersonList();
        }

        private void DeleteButtonPressed()
        {
            Person selectedPerson = _view.GetSelectedListItem();

            if (selectedPerson != null)
            {
                _manager.DeletePerson(selectedPerson);
                LoadPersonList();
            }
            else
            {
                _view.ShowWarning("Delete Person", "Please select a person to delete");
            }
        }

        private void ViewButtonPressed()
        {
            Person selectedPerson = _view.GetSelectedListItem();

            if (selectedPerson != null)
            {
                IPersonDetailsPresenter detailsPresenter = ClientServiceLocator.PersonDetailsPresenter;
                //detailsPresenter.Start();
                detailsPresenter.ShowPerson(selectedPerson);
                detailsPresenter.ShowView(true);
            }
            else
            {
                _view.ShowWarning("View Person", "Please select a person to view");
            }
        }

        private void EditButtonPressed()
        {
            Person selectedPerson = _view.GetSelectedListItem();

            if (selectedPerson != null)
            {
                IPersonDetailsPresenter detailsPresenter = ClientServiceLocator.PersonDetailsPresenter;
                //detailsPresenter.Start();
                detailsPresenter.EditPerson(selectedPerson);
                detailsPresenter.ShowView(true);
                LoadPersonList();
            }
            else
            {
                _view.ShowWarning("Edit Person", "Please select a person to edit");
            }
        }

        private void LoadPersonList()
        {
            _view.SetWaitCursor();
            _personList = (List<Person>)_manager.GetAllPeople();
            _view.SetPersonList(_personList);
            _view.SetDefaultCursor();
        }
    }
}
