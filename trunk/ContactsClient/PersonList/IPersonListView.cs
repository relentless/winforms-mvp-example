using System.Collections.Generic;
using ContactsDomain.DomainObjects;
using ContactsClient.PersonDetails;

namespace ContactsClient.PersonList
{
    public interface IPersonListView
    {
        IPersonListPresenter Presenter { set; }

        void ShowView();

        void SetPersonList(List<Person> PersonList);

        Person GetSelectedListItem();

        void SetWaitCursor();

        void SetDefaultCursor();

        void ShowWarning(string Title, string Message);

        event ViewEvent LoadButtonPressed;
        event ViewEvent AddButtonPressed;
        event ViewEvent ViewButtonPressed;
        event ViewEvent EditButtonPressed;
        event ViewEvent DeleteButtonPressed;
    }
}
