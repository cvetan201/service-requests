using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MaintenanceRequests.Dtos
{
    public class AddMaintenanceRequestDto
    {
        [Required]
        public string BuildingCode { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string CreatedBy { get; set; }
    }
}
