using System;
using ContactsClient.PersonDetails;

namespace ContactsClient.Tests
{
    class FakeViewFactory: IViewFactory
    {
        private IPersonDetailsView _detailsView;

        public FakeViewFactory(IPersonDetailsView DetailsView)
        {
            _detailsView = DetailsView;
        }

        public FakeViewFactory()
        {
            _detailsView = new FakePersonDetailsView();
        }

        public IPersonDetailsView CreateDetailsView()
        {
             return _detailsView;
        }

    }
}
