using System;
using System.Collections.Generic;

namespace ToysAndGameWeb
{
    public partial class Company
    {
        public Company()
        {
            Products = new HashSet<Products>();
        }

        public int CompanyId { get; set; }
        public string Company1 { get; set; }

        public ICollection<Products> Products { get; set; }
    }
}
