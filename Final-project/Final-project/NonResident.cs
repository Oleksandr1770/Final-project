using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_project
{
    public class NonResident : Client
    {
        public override List<string> Services()
        {
            FileManager fileManager = FileManager.Instance();
            return fileManager.ReadServices()["NonResident"];
        }
    }
}
