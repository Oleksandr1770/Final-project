using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Final_project
{
    [Serializable]
    public enum Sex
    {
        [XmlEnum("Male")]
        Male,
        [XmlEnum("Female")]
        Female,
        [XmlEnum("Other")]
        Other
    }

    [Serializable]
    public enum MaritalStatus
    {
        [XmlEnum("Married")]
        Married,
        [XmlEnum("Divorced")]
        Divorced,
        [XmlEnum("Single")]
        Single,
        [XmlEnum("Widowed")]
        Widowed
    }

    
    public abstract class Client : IClient
    {
        private string firstName;
        private string lastName;
        private string email;
        private string phoneNumber;
        private int age;
        private string citizenship;
        private MaritalStatus maritalStatus;
        private Sex sex;

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Email { get => email; set => email = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public int Age { get => age; set => age = value; }
        public string Citizenship { get => citizenship; set => citizenship = value; }
        public MaritalStatus MaritalStatus { get => maritalStatus; set => maritalStatus = value; }
        public Sex Sex { get => sex; set => sex = value; }

        public abstract List<string> Services();
    }
}
