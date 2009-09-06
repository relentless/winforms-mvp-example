using System.Collections.Generic;
using ContactsClient.PersonList;
using ContactsClient.PersonDetails;
using ContactsDomain.DomainObjects;
using ContactsClient;
using System;
using System.Threading;

internal class FakePersonListView : IPersonListView
{
    internal List<Person> PersonList { get; set; }
    internal bool GetSeletedListItemCalled { get; set; }
    internal DateTime WaitCursorSetTime { get; set; }
    internal DateTime DefaultCursorSetTime { get; set; }
    internal string WarningMessage { get; set; }
    internal Person ViewPerson { get; set; }

    public event ViewEvent LoadButtonPressed;
    public event ViewEvent AddButtonPressed;
    public event ViewEvent ViewButtonPressed;
    public event ViewEvent EditButtonPressed;
    public event ViewEvent DeleteButtonPressed;

    public void SetPersonList(System.Collections.Generic.List<ContactsDomain.DomainObjects.Person> PersonList)
    {
        this.PersonList = PersonList;
    }

    public IPersonListPresenter Presenter
    {
        set { }
    }

    public void ShowView()
    { }

    public Person GetSelectedListItem()
    {
        GetSeletedListItemCalled = true;
        if (PersonList != null)
            if (PersonList.Count > 0)
                return PersonList[0];

        return null;
    }

    public void ShowWarning(string Title, string message)
    {
        WarningMessage = message;
    }

    public void PressLoadButton()
    {
        LoadButtonPressed.Invoke();
    }

    public void PressAddButton()
    {
        AddButtonPressed.Invoke();
    }

    public void PressEditButton()
    {
        EditButtonPressed.Invoke();
    }

    public void PressViewButton()
    {
        ViewButtonPressed.Invoke();
    }

    public void PressDeleteButton()
    {
        DeleteButtonPressed.Invoke();
    }

    public void SetWaitCursor()
    {
        // need to pause otherwise times may be identical
        Thread.Sleep(5);
        WaitCursorSetTime = System.DateTime.Now;
    }

    public void SetDefaultCursor()
    {
        // need to pause otherwise times may be identical
        Thread.Sleep(5);
        DefaultCursorSetTime = System.DateTime.Now;
    }
}