using System;
using System.Collections.Generic;

namespace Tunnels.Core.Models {
    public class Order {
        public int Id { get; set; }
        public DateTime DateAdded { get; set; }
        public IList<ProductEntry> ProductsEntries { get; set; } = new List<ProductEntry>();
        public int? UserId { get; set; }
        public User? User { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }
        public double Total { get; set; }
        public OperationTypeEnum OperationType { get; set; }
    }
}
