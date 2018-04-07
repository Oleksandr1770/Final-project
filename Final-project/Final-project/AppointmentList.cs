using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Final_project
{
    class AppointmentList
    {
        private ObservableCollection<Appointment> appointments = null;

        public AppointmentList() => appointments = new ObservableCollection<Appointment>();

        public Appointment this[int i]
        {
            get => appointments[i];
            set => appointments[i] = value;
        }
        public void Add(Appointment a) => appointments.Add(a);
        public void AddRange(ObservableCollection<Appointment> a)
        {
            for (int i = 0; i < a.Count; i++)
            {
                appointments.Add(a[i]);
            }
        }
        public void Remove(Appointment a) => appointments.Remove(a);
        public int Count => appointments.Count;
        public bool Contains(Appointment a) => appointments.Contains(a);
        public void Clear() => appointments.Clear();

        public void Sort()
        {
            List<Appointment> list = new List<Appointment>(appointments);
            list.Sort();
            appointments.Clear();
            for (int i = 0; i < list.Count; i++)
            {
                appointments.Add(list[i]);
            }
        }
    }
}
