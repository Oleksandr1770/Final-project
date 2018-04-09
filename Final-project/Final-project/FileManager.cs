using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Final_project
{
    class FileManager
    {
        private const string appointmentsFile = "appointments.xml";
        private const string timeFile = "time.xml";
        private const string servicesFile = "services.xml";

        private XmlReaderSettings readerSettings = null;

        private static FileManager instance = new FileManager();
        private List<Type> clientTypes;

        private FileManager()
        {
            clientTypes = new List<Type>
            {
                typeof(Resident),
                typeof(NonResident)
            };
            ManageFile();
        }

        public static FileManager Instance()
        {
            return instance;
        }

        public AppointmentList ReadAppointments()
        {
            AppointmentList appointmentList = null;
            XmlSerializer serializer = new XmlSerializer(typeof(AppointmentList), clientTypes.ToArray());
            StreamReader reader = new StreamReader(appointmentsFile);
            appointmentList = (AppointmentList)serializer.Deserialize(reader);
            reader.Close();
            return appointmentList;
        }

        public void WriteAppointments(AppointmentList appointmentList)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(AppointmentList), clientTypes.ToArray());
            TextWriter writer = new StreamWriter(appointmentsFile);
            serializer.Serialize(writer, appointmentList);
            writer.Close();
        }

        public Queue<string> ReadTime()
        {
            Queue<string> timeOptions = new Queue<string>();
            XmlReader reader = XmlReader.Create(timeFile, readerSettings);
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Text)
                {
                    timeOptions.Enqueue(reader.Value);
                }
            }
            reader.Close();
            return timeOptions;
        }

        public Dictionary<string, List<string>> ReadServices()
        {
            Dictionary<string, List<string>> services = new Dictionary<string, List<string>>();
            List<string> nonResidentServices = new List<string>();
            List<string> residentServices = new List<string>();

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(servicesFile);

            XmlNodeList residentNodeList = xmlDocument.GetElementsByTagName("Resident")[0].ChildNodes;
            XmlNodeList nonResidentNodeList = xmlDocument.GetElementsByTagName("NonResident")[0].ChildNodes;

            for (int i = 0; i < residentNodeList.Count; i++)
            {
                residentServices.Add(residentNodeList[i].InnerXml);
            }
            for (int i = 0; i < nonResidentNodeList.Count; i++)
            {
                nonResidentServices.Add(nonResidentNodeList[i].InnerXml);
            }

            services.Add("Resident", residentServices);
            services.Add("NonResident", nonResidentServices);
         return services;
        }

        private void ManageFile()
        {
            if (!File.Exists(appointmentsFile))
            {
                //Free resources
                using (File.Create(appointmentsFile)) { }
            }
            if (!File.Exists(timeFile)) throw new XmlFileNotFoundException();
            if (!File.Exists(servicesFile)) throw new XmlFileNotFoundException();

            readerSettings = new XmlReaderSettings
            {
                IgnoreWhitespace = true,
                IgnoreComments = true
            };

        }
    }
}
