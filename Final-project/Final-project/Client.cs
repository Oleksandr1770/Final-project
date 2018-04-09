using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_project
{
    enum MaritalStatus
    {
        Married,
        Divorced,
        Single,
        Widowed
    }
    enum Sex
    {
        Male,
        Female,
        Other
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
        internal MaritalStatus MaritalStatus { get => maritalStatus; set => maritalStatus = value; }
        internal Sex Sex { get => sex; set => sex = value; }

        public abstract string[] Services();
    }
}
