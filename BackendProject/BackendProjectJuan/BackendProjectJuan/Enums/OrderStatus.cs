using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendProjectJuan.Enums
{
    public enum OrderStatus
    {
        Pending = 1,
        Accepted = 2,
        Rejected = 3,
        Canceled = 4,
        OnDelivery = 5,
        Delivered = 6
    }
}
