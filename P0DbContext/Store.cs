using System;
using System.Collections.Generic;

#nullable disable

namespace P0DbContext
{
    public partial class Store
    {
        public Store()
        {
            Customers = new HashSet<Customer>();
            StoreInventories = new HashSet<StoreInventory>();
        }

        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public string StoreAddr1 { get; set; }
        public string StoreAddr2 { get; set; }
        public string StoreCity { get; set; }
        public string StoreState { get; set; }
        public string StoreZip { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<StoreInventory> StoreInventories { get; set; }
    }
}
