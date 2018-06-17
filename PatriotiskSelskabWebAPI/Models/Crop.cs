using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatriotiskSelskabWebAPI.Models
{
    public class Crop
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Crop(string name)
        {
            Name = name;
        }
    }
}
