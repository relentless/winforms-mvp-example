using ContactsDomain.DomainObjects;

namespace ContactsClient.PersonDetails
{
    public interface IPersonDetailsPresenter
    {
        void Start();

        void ShowView(bool Modal);

        void OkButtonPressed();

        void ViewClosed();

        void ShowPerson(Person person);

        void EditPerson(Person person);
    }
}
