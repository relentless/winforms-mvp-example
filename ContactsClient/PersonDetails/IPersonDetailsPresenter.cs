using ContactsDomain.DomainObjects;

namespace ContactsClient.PersonDetails
{
    public interface IPersonDetailsPresenter
    {
        void ShowView(bool Modal);

        IPersonDetailsView View { get; }

        void OkButtonPressed();

        void AddPerson();

        void ShowPerson(Person person);

        void EditPerson(Person person);
    }
}
