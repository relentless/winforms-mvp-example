using ContactsClient.PersonList;
using ContactsClient.PersonDetails;

namespace ContactsClient
{
    public static class ClientServiceLocator
    {
        private static IPersonDetailsPresenter _personDetailsPresenter;
        private static IPersonListPresenter _personListPresenter;

        public static IPersonDetailsPresenter PersonDetailsPresenter
        {
            get
            {
                if (_personDetailsPresenter == null)
                    throw new System.ApplicationException("PersonDetailsPresenter not set");

                return _personDetailsPresenter;
            }
            set
            {
                _personDetailsPresenter = value;
            }
        }

        public static IPersonListPresenter PersonListPresenter
        {
            get
            {
                if (_personListPresenter == null)
                    throw new System.ApplicationException("PersonListPresenter not set");

                return _personListPresenter;
            }
            set
            {
                _personListPresenter = value;
            }
        }
    }
}
