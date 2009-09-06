using System;
using System.Windows.Forms;

namespace ContactsClient.PersonDetails
{
    public sealed partial class PersonDetailsView : Form, IPersonDetailsView
    {
        private IPersonDetailsPresenter _presenter;

        public PersonDetailsView()
        {
            InitializeComponent();
        }

        #region IPersonDetailsView Members

        public IPersonDetailsPresenter Presenter
        {
            set { _presenter = value; }
        }

        public void ShowForm(bool Modal)
        {
            if (Modal)
            {
                ShowDialog();
            }
            else
            {
                Show();
            }
        }

        public void CloseForm()
        {
            Close();
        }

        public string Title
        {
            get { return Text; }
            set { Text = value; }
        }

        public string Forename
        {
            get { return txtForename.Text; }
            set { txtForename.Text = value; }
        }

        public string Surname
        {
            get { return txtSurname.Text; }
            set { txtSurname.Text = value; }
        }

        public string BirthdayDay
        {
            get { return txtBirthdayDay.Text; }
            set { txtBirthdayDay.Text = value; }
        }

        public string BirthdayMonth
        {
            get { return txtBirthdayMonth.Text; }
            set { txtBirthdayMonth.Text = value; }
        }

        #endregion

        private void btnOk_Click(object sender, EventArgs e)
        {
            _presenter.OkButtonPressed();
        }
    }
}
