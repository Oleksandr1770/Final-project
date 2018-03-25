using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_project
{
    class Resident : Client
    {
        public override string[] Services()
        {
            return new string[]
            {
                "Visitor VISA",
                "Visitor status extension",
                "Tourist VISA",
                "Student VISA",
                "Study Permit",
                "Study Permit extension",
                "Co-op Work Permit",
                "Post Graduate Work Permit"
            };
        }
    }
}
