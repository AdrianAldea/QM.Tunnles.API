using System;
using Tunnels.Core.Models;

namespace Tunnels.DTOs.User {
    /// <summary>
    /// CreateOrderResponse
    /// </summary>
    public class CreateOrderResponse {
        public int Id { get; set; }
        public DateTime DateAdded { get; set; }
        public int? ProductId { get; set; }
        public Tunnels.Core.Models.Product Product { get; set; }
        public int? UserId { get; set; }
        public Tunnels.Core.Models.User? User { get; set; }
        public double Stock { get; set; }
        public double Price { get; set; }
        public bool IsActive { get; set; }
        public OperationTypeEnum OperationType { get; set; }
    }
}
