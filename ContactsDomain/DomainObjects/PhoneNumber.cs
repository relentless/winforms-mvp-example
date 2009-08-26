namespace ContactsDomain.DomainObjects
{
    public class PhoneNumber
    {
        protected PhoneNumber()
        { }

        public PhoneNumber(int Id, string Number)
        {
            this.Id = Id;
            this.Number = Number;
        }

        public virtual int Id { get; set; }
        public virtual string Number { get; set; }
    }
}
