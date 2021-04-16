using MaintenanceRequests.Dtos;
using MaintenanceRequests.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MaintenanceRequests.Services
{
    public interface IMaintenanceRequestService
    {
        IList<MaintenanceRequest> GetAllMaintenanceRequests();

        MaintenanceRequest GetMaintenanceRequestById(Guid id);

        IList<MaintenanceRequest> CreateNewMaintenanceRequest(AddMaintenanceRequestDto request);

        IList<MaintenanceRequest> UpdateMaintenanceRequest(UpdateMaintenanceRequestDto request);

        IList<MaintenanceRequest> DeleteMaintenanceRequestById(Guid id);
    }
}
