using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_project
{
    public class Appointment : IComparable
    {
        private string time;
        private string date;
        private Client client;
        private string service;

        public Appointment() { }

        public Appointment(string time, string dateTime, Client client, string service)
        {
            this.Time = time;
            this.Date = dateTime;
            this.Client = client;
            this.Service = service;
        }

        public string Time { get => time; set => time = value; }
        public string Date { get => date; set => date = value; }
        public string Service { get => service; set => service = value; }
        public Client Client { get => client; set => client = value; }

        //Compare the dates
        public int CompareTo(object obj)
        {
            Appointment a = (Appointment)obj;
            return Date.CompareTo(a.Date);
        }
    }
}
