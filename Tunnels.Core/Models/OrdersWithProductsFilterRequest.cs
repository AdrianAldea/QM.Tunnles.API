using System;

namespace Tunnels.Core.Models {
    public class OrdersWithProductsFilterRequest {
        public FilterTypeEnum? FilterType { get; set; } = null;
        public DateTime? StartDate { get; set; } = null;
        public DateTime? EndDate { get; set; } = null;
        public double? ProductId { get; set; } = null;
        public double? OrderId { get; set; } = null;
        public bool? IsActive { get; set; } = null;
    }
}
