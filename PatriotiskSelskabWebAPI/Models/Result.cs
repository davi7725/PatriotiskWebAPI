using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatriotiskSelskabWebAPI.Models
{
    public class Result
    {
        public string Value { get; set; }
        public UnitType Unit { get; set; }
        public Result(string value, UnitType unit)
        {
            Value = value;
            Unit = unit;
        }

    }
}
