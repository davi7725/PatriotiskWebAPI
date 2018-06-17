using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatriotiskSelskabWebAPI.Models
{
    public class TreatmentType
    {
        public string Name { get; set; }

        public TreatmentType(string name)
        {
            Name = name;
        }
    }
}
