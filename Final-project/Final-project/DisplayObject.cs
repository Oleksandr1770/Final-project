using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_project
{
    public class DisplayObject
    {
        private string firstName;
        private string lastName;
        private string email;
        private string phoneNumber;
        private string age;
        private string citizenship;
        private string currentStatus;
        private Sex sex;
        private MaritalStatus maritalStatus;
        private string typeOfService;
        private DateTime appointmentDate;
        private string appointmentTime;

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Email { get => email; set => email = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Age { get => age; set => age = value; }
        public string Citizenship { get => citizenship; set => citizenship = value; }
        public string CurrentStatus { get => currentStatus; set => currentStatus = value; }
        public Sex Sex { get => sex; set => sex = value; }
        public MaritalStatus MaritalStatus { get => maritalStatus; set => maritalStatus = value; }
        public string TypeOfService { get => typeOfService; set => typeOfService = value; }
        public DateTime AppointmentDate { get => appointmentDate; set => appointmentDate = value; }
        public string AppointmentTime { get => appointmentTime; set => appointmentTime = value; }
        public void Clear()
        {
            this.FirstName = null;
            this.LastName = null;
            this.Email = null;
            this.PhoneNumber = null;
            this.Age = null;
            this.Citizenship = null;
            this.CurrentStatus = null;
            this.Sex = Sex.Male;
            this.MaritalStatus = MaritalStatus.Single;
            this.typeOfService = null;
            this.AppointmentDate = DateTime.Now;
            this.AppointmentTime = null;
        }
    }
}
