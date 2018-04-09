using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
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
        private FileManager fileManager = FileManager.Instance();
        private Dictionary<string, List<string>> services = new Dictionary<string, List<string>>();
        private Queue<string> timeOptions = new Queue<string>();


        public MainWindow()
        {
            InitializeComponent();
            AppointmentList = fileManager.ReadAppointments();
            services = fileManager.ReadServices();
            timeOptions = fileManager.ReadTime();
            DataContext = this;
        }

        public AppointmentList AppointmentList { get => appointmentList; set => appointmentList = value; }
        public Dictionary<string, List<string>> Services { get => services; set => services = value; }
    }
}
