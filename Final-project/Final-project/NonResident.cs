using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_project
{
    class NonResident : Client
    {
        public override string[] Services()
        {
            
            return new string[]
            {
                "Visitor VISA",
                "Tourist VISA",
                "Student VISA",
                "Study Permit",
                "Co-op Work Permit",
                "Post Graduate Work Permit"
            };
        }
    }
}
