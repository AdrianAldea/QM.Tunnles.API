using System;

namespace Tunnels.Core.Models {
    [Flags]
    public enum FilterTypeEnum {
        NoFilter = 0,
        ByDate = 1,
        ByProductId = 2,
        ByOrderId = 4,
        ByDateAndProductId = 8
    }
}