using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Final_project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DisplayObject displayObject = new DisplayObject();
        private AppointmentList appointmentList = new AppointmentList();
        private FileManager fileManager = null;
        private Queue<string> timeOptions = new Queue<string>();
        private Resident resident = new Resident();
        private NonResident nonResident = new NonResident();
        private DateTime filterDate = new DateTime();


        public MainWindow()
        {
            InitializeComponent();
            //Closing the program when the files are not found
            try
            {
                fileManager = FileManager.Instance();
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
                MessageBox.Show("Files cannot be loaded. Finishing the program...");
                Environment.Exit(0);
            }
            
            AppointmentList = fileManager.ReadAppointments();
            if (appointmentList == null)
            {
                appointmentList = new AppointmentList();
            }
            timeOptions = fileManager.ReadTime();
            LoadDefaultValues();
            DataContext = this;
        }

        private void LoadDefaultValues()
        {
            //Loading current status
            statusComboBox.Items.Add("Resident");
            statusComboBox.Items.Add("Non-resident");
            displayObject.CurrentStatus = statusComboBox.Items.GetItemAt(0).ToString();

            //Loading sex
            sexComboBox.Items.Add(Sex.Male);
            sexComboBox.Items.Add(Sex.Female);
            sexComboBox.Items.Add(Sex.Other);
            displayObject.Sex = Sex.Male;

            //Loading marital status
            maritalStatusComboBox.Items.Add(MaritalStatus.Single);
            maritalStatusComboBox.Items.Add(MaritalStatus.Married);
            maritalStatusComboBox.Items.Add(MaritalStatus.Divorced);
            maritalStatusComboBox.Items.Add(MaritalStatus.Widowed);
            displayObject.MaritalStatus = MaritalStatus.Single;

            //Loading appointment date
            displayObject.AppointmentDate = DateTime.Now;
        }

        public AppointmentList AppointmentList { get => appointmentList; set => appointmentList = value; }
        public DisplayObject DisplayObject { get => displayObject; set => displayObject = value; }
        public DateTime FilterDate { get => filterDate; set => filterDate = value; }

        private void StatusChanged(object sender, SelectionChangedEventArgs e)
        {
            serviceComboBox.Items.Clear();
            
            List<string> services;
            switch(displayObject.CurrentStatus)
            {
                case "Resident":
                    services = resident.Services();
                    for (int i = 0; i < services.Count; i++)
                    {
                        serviceComboBox.Items.Add(services[i]);
                    }
                    break;
                case "Non-resident":
                    services = nonResident.Services();
                    for (int i = 0; i < services.Count; i++)
                    {
                        serviceComboBox.Items.Add(services[i]);
                    }
                    break;
                default:
                    break;
            }
            serviceComboBox.SelectedIndex = 0;
            displayObject.TypeOfService = serviceComboBox.SelectedItem.ToString();
        }

        private void DateChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateTimeOptions();
        }

        private void UpdateTimeOptions()
        {
            appointmentTimeComboBox.Items.Clear();
            foreach (string time in timeOptions)
            {
                appointmentTimeComboBox.Items.Add(time);
            }
            if (appointmentList != null)
            {
                for (int i = 0; i < appointmentList.Count; i++)
                {
                    if (appointmentList[i].Date == displayObject.AppointmentDate.ToString("MM/dd/yyyy"))
                    {
                        appointmentTimeComboBox.Items.Remove(appointmentList[i].Time);
                    }
                }
            }
            appointmentTimeComboBox.SelectedIndex = 0;
            displayObject.AppointmentTime = appointmentTimeComboBox.SelectedItem.ToString();
        }

        private void SubmitBtn(object sender, RoutedEventArgs e)
        {
            if (!ValidateData()) return;
            SaveAppointment();
            ResetData();
        }

        private bool ValidateData()
        {
            if (displayObject.FirstName == "" || displayObject.FirstName == null ||
                displayObject.LastName == "" || displayObject.LastName == null ||
                displayObject.Email == "" || displayObject.Email == null ||
                displayObject.PhoneNumber == "" || displayObject.PhoneNumber == null ||
                displayObject.Age == "" || displayObject.Age == null ||
                displayObject.Citizenship == "" || displayObject.Citizenship == null ||
                displayObject.CurrentStatus == null || displayObject.TypeOfService == null ||
                displayObject.AppointmentDate == null || displayObject.AppointmentTime == "" ||
                displayObject.AppointmentTime == null)
            {
                return false;
            }
            if (int.TryParse(displayObject.Age, out int age))
            {
                if (age >= 0 && age <= 120)
                {
                    return true;
                }
                else return false;
            }
            else return false;
        }

        private void ResetData()
        {
            displayObject.Clear();
            firstName.Text = displayObject.FirstName;
            lastName.Text = displayObject.LastName;
            email.Text = displayObject.Email;
            phoneNumber.Text = displayObject.PhoneNumber;
            age.Text = displayObject.Age;
            citizenship.Text = displayObject.Citizenship;
            statusComboBox.SelectedIndex = 0;
            statusComboBox.SelectedItem = statusComboBox.Items.GetItemAt(0);
            sexComboBox.SelectedIndex = 0;
            maritalStatusComboBox.SelectedIndex = 0;
            datePicker.Text = displayObject.AppointmentDate.ToString("MM/dd/yyyy");
            UpdateTimeOptions();
        }

        private void SaveAppointment()
        {
            Appointment a = new Appointment();
            a.Date = displayObject.AppointmentDate.ToString("MM/dd/yyyy");
            a.Time = displayObject.AppointmentTime;
            a.Service = displayObject.TypeOfService;
            switch(displayObject.CurrentStatus)
            {
                case "Resident":
                    a.Client = new Resident();
                    break;
                case "Non-resident":
                    a.Client = new NonResident();
                    break;
            }
            a.Client.FirstName = displayObject.FirstName;
            a.Client.LastName = displayObject.LastName;
            a.Client.Email = displayObject.Email;
            a.Client.PhoneNumber = displayObject.PhoneNumber;
            a.Client.Age = int.Parse(displayObject.Age);
            a.Client.Citizenship = displayObject.Citizenship;
            a.Client.Sex = displayObject.Sex;
            a.Client.MaritalStatus = displayObject.MaritalStatus;

            appointmentList.Add(a);
            fileManager.WriteAppointments(appointmentList);
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            fileManager.WriteAppointments(appointmentList);
            MessageBox.Show("Data successfully updated");
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            appointmentList.RemoveAt(dataGrid.SelectedIndex);
            fileManager.WriteAppointments(appointmentList);
        }

        private void filterChanged(object sender, SelectionChangedEventArgs e)
        {
            var query = from a in appointmentList.Appointments
                        where a.Date == filterDate.ToString("MM/dd/yyyy")
                        select a;
            dataGrid.ItemsSource = query.ToList();
        }

        private void Reset(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = appointmentList.Appointments;
        }
    }
}
