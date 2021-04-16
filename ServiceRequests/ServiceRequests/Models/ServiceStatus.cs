using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaintenanceRequests.Models
{
    public enum ServiceStatus
    {
        NotApplicable = 1,
        Created = 2,
        InProgress = 3,
        Complete = 4,
        Canceled = 5
    }
}
