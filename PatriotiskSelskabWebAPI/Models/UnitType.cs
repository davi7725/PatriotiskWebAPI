using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatriotiskSelskabWebAPI.Models
{
    public class UnitType
    {
        public string Name { get; set; }

        public UnitType(string name)
        {
            Name = name;
        }

    }
}
