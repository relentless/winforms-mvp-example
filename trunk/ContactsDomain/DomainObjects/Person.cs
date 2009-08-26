using System.Collections.Generic;
using Iesi.Collections.Generic;

namespace ContactsDomain.DomainObjects
{
    public class Person
    {
        public virtual int Id { get; set; }
        public virtual string Forename { get; set; }
        public virtual string Surname { get; set; }
        public virtual short BirthdayMonth { get; set; }
        public virtual short BirthdayDay { get; set; }
        public virtual ISet<string> EmailAddresses
        {
            get { return _emailAddresses; }
            set { _emailAddresses = value; }
        }

        private ISet<string> _emailAddresses = new HashedSet<string>();

        public virtual void AddEmail(string NewEmail)
        {
            _emailAddresses.Add(NewEmail);
        }

        public virtual ISet<PhoneNumber> PhoneNumbers
        {
            get { return _phoneNumbers; }
            set { _phoneNumbers = value; }
        }

        private ISet<PhoneNumber> _phoneNumbers = new HashedSet<PhoneNumber>();

        public virtual void AddPhoneNumber(PhoneNumber NewNumber)
        {
            _phoneNumbers.Add(NewNumber);
        }
    }
}
