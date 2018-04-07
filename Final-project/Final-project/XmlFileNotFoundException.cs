using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Final_project
{
    class XmlFileNotFoundException : Exception
    {
        public XmlFileNotFoundException()
        {
        }

        public XmlFileNotFoundException(string message) : base(message)
        {
        }

        public XmlFileNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected XmlFileNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
