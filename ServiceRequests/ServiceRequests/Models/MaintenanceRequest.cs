using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaintenanceRequests.Models
{
    public class MaintenanceRequest
    {
        public Guid Id { get; set; }  
        public string BuildingCode { get; set; }
        public string Description { get; set; }
        public ServiceStatus CurrentStatus { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }

    }
}
