using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_project
{
    class Appointment : IComparable
    {
        private string time;
        private DateTime dateTime;
        private Client client;
        private string service;

        public Appointment() { }

        public Appointment(string time, DateTime dateTime, Client client, string service)
        {
            this.time = time;
            this.dateTime = dateTime;
            this.client = client;
            this.service = service;
        }

        //Compare the dates
        public int CompareTo(object obj)
        {
            Appointment a = (Appointment)obj;
            return dateTime.CompareTo(a.dateTime);
        }
    }
}
