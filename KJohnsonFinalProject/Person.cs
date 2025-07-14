using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KJohnsonFinalProject
{
    /// <summary>
    /// Represents a person with contact and account details.
    /// </summary>
    public class Person
    {
        //Getters and Setters for Person
        public int PersonID { get; set; }
        public string Title { get; set; }
        public string NameFirst { get; set; }
        public string NameMiddle { get; set; }
        public string NameLast { get; set; }
        public string Suffix { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string Email { get; set; }
        public string PhonePrimary { get; set; }
        public string PhoneSecondary { get; set; }
        public string LogonName { get; set; }
        public int PositionID { get; set; }
        public string PositionTitle { get; set; }
        public bool AccountDisabled { get; set; }
        public bool AccountDeleted { get; set; }
    }
}
