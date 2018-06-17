using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatriotiskSelskabWebAPI.Models
{
    public class Product
    {
        public string Name { get; set; }
        public string Owner { get; set; }
        public ProductCategory Category { get; set; }

        public Product(string name, string owner, ProductCategory category)
        {
            Name = name;
            Owner = owner;
            Category = category;
        }

    }
}
