using System;
using System.Collections.Generic;

namespace Tunnels.Core.Models {
    public class ProductEntry {
        public int ProductId { get; set; }
        public IList<Order> Orders { get; set; } = new List<Order>();
        public Product Product { get; set; }
        public int Id { get; set; }
        public DateTime DateAdded { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }
        public double Total { get; set; }
        public string Type { get; set; }
    }
}
