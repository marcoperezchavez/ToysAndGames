using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToysAndGameWeb.Models
{
    public class ProductsGNL
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DescriptionToy { get; set; }
        public int AgeRestriction { get; set; }
        public decimal Price { get; set; }
        public string Company { get; set; }
    }
}
