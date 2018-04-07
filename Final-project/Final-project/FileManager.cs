using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Final_project
{
    class FileManager
    {
        private string appointmentsFile = "appointments.xml";
        private string timeFile = "time.xml";
        private string servicesFile = "services.xml";

        private XmlWriterSettings writerSettings = null;
        private XmlReaderSettings readerSettings = null;

        public FileManager()
        {
            ManageFile();
        }

        public AppointmentList ReadAppointments()
        {
            AppointmentList appointmentList = new AppointmentList();

            Appointment a = null;

            XmlReader reader = XmlReader.Create(appointmentsFile, readerSettings);

            return appointmentList;
        }

        public void WriteAppointments(AppointmentList appointmentList)
        {
            XmlWriter writer = XmlWriter.Create(appointmentsFile, writerSettings);
            writer.WriteStartDocument();
            writer.WriteStartElement("Appointments");

            writer.WriteEndElement();
            writer.Close();
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
            writerSettings = new XmlWriterSettings();
            writerSettings.Indent = true;
            writerSettings.IndentChars = "\t";

            readerSettings = new XmlReaderSettings();
            readerSettings.IgnoreWhitespace = true;
            readerSettings.IgnoreComments = true;

        }
    }
}
