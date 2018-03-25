using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_project
{
    class AppointmentList
    {
        private List<Appointment> appointments = null;

        public AppointmentList() => appointments = new List<Appointment>();

        public Appointment this[int i]
        {
            get => appointments[i];
            set => appointments[i] = value;
        }
        public void Add(Appointment a) => appointments.Add(a);
        public void Remove(Appointment a) => appointments.Remove(a);
        public int Count => appointments.Count;
        public bool Contains(Appointment a) => appointments.Contains(a);
        public void Clear() => appointments.Clear();

        public void Sort()
        {
            appointments.Sort();
        }
    }
}
