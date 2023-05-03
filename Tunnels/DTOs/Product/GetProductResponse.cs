using System;
using System.Collections.Generic;
using Tunnels.Core.Models;

namespace Tunnels.DTOs.Product {
    public class GetProductResponse {
        public int Id { get; set; }
        public DateTime DateAdded { get; set; }
        public string Name { get; set; }
        public string DistributionCompany { get; set; }
        public double Total { get; set; }
        public bool IsActive { get; set; }
        public string Type { get; set; }
    }
}
