using MaintenanceRequests.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaintenanceRequests.Services
{
    public class MaintenanceRequestService : IMaintenanceRequestService
    {
        private static List<MaintenanceRequest> requests = new List<MaintenanceRequest>
        {
            new MaintenanceRequest{
                Id = new Guid(),
                BuildingCode ="COH",
                Description="Please turn up the AC in suite 1200D. It is too hot here.",
                CurrentStatus = ServiceStatus.Created,
                CreatedBy ="Nik Patel",
                CreatedDate = DateTime.Now,
                LastModifiedBy = "Jane Doe",
                LastModifiedDate = DateTime.Now
            }
        };

        public IList<MaintenanceRequest> CreateNewMaitenanceRequest(MaintenanceRequest request)
        {
            requests.Add(request);
            return requests;
        }

        public IList<MaintenanceRequest> DeleteMainteanceRequestById(Guid id)
        {
            requests.RemoveAll(x => x.Id == id);
            return requests;
        }

        public MaintenanceRequest GetMainteanceRequestById(Guid id)
        {
            return requests.FirstOrDefault(x => x.Id == id);
        }

        public IList<MaintenanceRequest> GetAllMaintenanceRequests()
        {
            return requests;
        }

        public IList<MaintenanceRequest> UpdateMaitenanceRequest(MaintenanceRequest request)
        {
            return requests.Where(x => x.Id == request.Id)
                .Select(y => { y = request; return y; })
                .ToList();
        }
    }
}
