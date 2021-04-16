using MaintenanceRequests.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MaintenanceRequests.Services
{
    public interface IMaintenanceRequestService
    {
        IList<MaintenanceRequest> GetAllMaintenanceRequests();

        MaintenanceRequest GetMainteanceRequestById(Guid id);

        IList<MaintenanceRequest> CreateNewMaitenanceRequest(MaintenanceRequest request);

        IList<MaintenanceRequest> UpdateMaitenanceRequest(MaintenanceRequest request);

        IList<MaintenanceRequest> DeleteMainteanceRequestById(Guid id);
    }
}
