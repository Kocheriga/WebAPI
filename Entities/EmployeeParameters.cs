using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
        public class EmployeeParameters : RequestParameters
        {
            public uint MinAge { get; set; }
            public uint MaxAge { get; set; } = int.MaxValue;
            public bool ValidAgeRange => MaxAge > MinAge;
        }
}
