using System;
using System.Collections.Generic;
using Tunnels.Core.Models;

namespace Tunnels.DTOs.User {
    /// <summary>
    /// CreateOrderRequest
    /// </summary>
    public class CreateOrderRequest {
        public int Id { get; set; }
        public DateTime DateAdded { get; set; }
        public IList<Tunnels.Core.Models.ProductEntry> ProductsEntries { get; set; } = new List<Tunnels.Core.Models.ProductEntry>();
        public int? UserId { get; set; }
        public Tunnels.Core.Models.User? User { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }
        public double Total { get; set; }
        public OperationTypeEnum OperationType { get; set; }
        public bool IsActive { get; set; }

    }
}
