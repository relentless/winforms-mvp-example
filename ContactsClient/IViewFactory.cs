using ContactsClient.PersonDetails;

namespace ContactsClient
{
    public interface IViewFactory
    {
        IPersonDetailsView DetailsView();
    }
}
