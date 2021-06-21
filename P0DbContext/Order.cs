using System;
using System.Collections.Generic;

#nullable disable

namespace P0DbContext
{
    public partial class Order
    {
        public Order()
        {
            OrdersItems = new HashSet<OrdersItem>();
        }

        public int OrderId { get; set; }
        public int OrderNumber { get; set; }
        public int? CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public int? StoreId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrdersItem> OrdersItems { get; set; }
    }
}
