using MaintenanceRequests.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MaintenanceRequests.Dtos
{
    public class UpdateMaintenanceRequestDto
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public ServiceStatus CurrentStatus { get; set; }
        [Required]
        public string LastModifiedBy { get; set; }
    }
}
