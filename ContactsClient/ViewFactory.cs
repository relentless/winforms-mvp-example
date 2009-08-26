using ContactsClient.PersonDetails;

namespace ContactsClient
{
    public class ViewFactory: IViewFactory
    {
        #region IViewFactory Members

        public IPersonDetailsView DetailsView()
        {
            return new PersonDetailsView();
        }

        #endregion
    }
}
