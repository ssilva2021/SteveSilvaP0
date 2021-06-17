using System;
using System.Collections.Generic;

#nullable disable

namespace P0DbContext
{
    public partial class Product
    {
        public Product()
        {
            OrdersItems = new HashSet<OrdersItem>();
            StoreInventories = new HashSet<StoreInventory>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDesc { get; set; }
        public decimal ProductPrice { get; set; }

        public virtual ICollection<OrdersItem> OrdersItems { get; set; }
        public virtual ICollection<StoreInventory> StoreInventories { get; set; }
    }
}
