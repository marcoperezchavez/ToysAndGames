using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToysAndGameWeb
{
    public partial class Products
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string DescriptionToy { get; set; }
        public int AgeRestriction { get; set; }
        public decimal Price { get; set; }
        public int? CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
