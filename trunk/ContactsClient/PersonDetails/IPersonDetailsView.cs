namespace ContactsClient.PersonDetails
{
    public interface IPersonDetailsView
    {
        IPersonDetailsPresenter Presenter { set; }

        void ShowForm(bool Modal);
        void CloseForm();
        
        string Title { get; set; }
        string Forename { get; set; }
        string Surname { get; set; }
        string BirthdayDay { get; set; }
        string BirthdayMonth { get; set; }
    }
}
