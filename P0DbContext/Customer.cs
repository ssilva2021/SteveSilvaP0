using System;
using System.Collections.Generic;

#nullable disable

namespace P0DbContext
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int CustomerId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int? Age { get; set; }
        public int? PrefferedStore { get; set; }

        public virtual Store PrefferedStoreNavigation { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
