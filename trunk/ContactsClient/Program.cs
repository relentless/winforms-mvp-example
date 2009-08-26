using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ContactsDomain.BusinessManagers;
using ContactsDataAccess.Repository;
using ContactsDataAccess.Utils;
using ContactsDomain.DomainObjects;
using ContactsClient.PersonList;
using ContactsClient.PersonDetails;

namespace ContactsClient
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //SchemaGenerator.GenerateDatabaseSchema();

            SetupServiceLocator();

            IPersonListPresenter listPresenter = ClientServiceLocator.PersonListPresenter;
            listPresenter.Start();

            Application.Run();
        }

        public static void SetupServiceLocator()
        {
            IPersonManager manager = new PersonManager(new PersonRepository());
            IViewFactory viewFactory = new ViewFactory();
            IPersonDetailsPresenter detailsPresenter = new PersonDetailsPresenter(viewFactory, manager);
            IPersonListView listView = new PersonListView();
            IPersonListPresenter listPresenter = new PersonListPresenter(listView, manager);
            ClientServiceLocator.PersonDetailsPresenter = detailsPresenter;
            ClientServiceLocator.PersonListPresenter = listPresenter;
        }
    }
}
