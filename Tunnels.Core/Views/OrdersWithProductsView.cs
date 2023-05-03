using System;
using Tunnels.Core.Models;

namespace Tunnels.Core.Views {
    public class OrdersWithProductsView {
        public double OrderId { get; set; }
        public string ProductName { get; set; }
        public string DistributionCompany { get; set; }
        public string ProductType { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }
        public double TotalProduct { get; set; }
        public double TotalOrder { get; set; }
        public DateTime? DateAdded { get; set; }
        public string CreatedByUser { get; set; }
        public OperationTypeEnum OperationType { get; set; }
        public bool? IsActive { get; set; }
    }
}
