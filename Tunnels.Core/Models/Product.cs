﻿using System;

namespace Tunnels.Core.Models {
    public class Product {
        public int Id { get; set; }
        public DateTime DateAdded { get; set; }
        public string Name { get; set; }
        public string DistributionCompany { get; set; }
        public string Type { get; set; }
        public bool IsActive { get; set; }
    }
}
