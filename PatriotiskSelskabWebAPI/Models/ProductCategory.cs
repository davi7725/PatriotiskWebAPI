using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatriotiskSelskabWebAPI.Models
{
    public class ProductCategory
    {
        public string Name { get; set; }

        public ProductCategory(string name)
        {
            Name = name;
        }

    }
}
