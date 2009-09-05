using ContactsClient.PersonDetails;

namespace ContactsClient
{
    public class ViewFactory: IViewFactory
    {
        #region IViewFactory Members

        public IPersonDetailsView CreateDetailsView()
        {
            return new PersonDetailsView();
        }

        #endregion
    }
}
