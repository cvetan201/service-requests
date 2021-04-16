using MaintenanceRequests.Dtos;
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
                Id = Guid.NewGuid(),
                BuildingCode ="COH",
                Description="Please turn up the AC in suite 1200D. It is too hot here.",
                CurrentStatus = ServiceStatus.Created,
                CreatedBy ="Nik Patel",
                CreatedDate = DateTime.Now,
                LastModifiedBy = "Jane Doe",
                LastModifiedDate = DateTime.Now
            },
             new MaintenanceRequest{
                Id = Guid.NewGuid(),
                BuildingCode ="COH",
                Description="Please change the lamp in the kitchen.",
                CurrentStatus = ServiceStatus.Created,
                CreatedBy ="Cvetan Kostadinov",
                CreatedDate = DateTime.Now,
                LastModifiedBy = "Peter Smith",
                LastModifiedDate = DateTime.Now
            },
        };

        public IList<MaintenanceRequest> CreateNewMaintenanceRequest(AddMaintenanceRequestDto addrequest)
        {
            var request = new MaintenanceRequest
            {
                Id = Guid.NewGuid(),
                BuildingCode = addrequest.BuildingCode,
                Description = addrequest.Description,
                CurrentStatus = ServiceStatus.Created,
                CreatedBy = addrequest.CreatedBy,
                CreatedDate = DateTime.Now,
                LastModifiedBy = addrequest.CreatedBy,
                LastModifiedDate = DateTime.Now
            };

            requests.Add(request);
            return requests;
        }

        public IList<MaintenanceRequest> DeleteMaintenanceRequestById(Guid id)
        {
            requests.RemoveAll(x => x.Id == id);
            return requests;
        }

        public MaintenanceRequest GetMaintenanceRequestById(Guid id)
        {
            return requests.FirstOrDefault(x => x.Id == id);
        }

        public IList<MaintenanceRequest> GetAllMaintenanceRequests()
        {
            return requests;
        }

        public IList<MaintenanceRequest> UpdateMaintenanceRequest(UpdateMaintenanceRequestDto updateRequest)
        {
            var request = requests.First(x => x.Id == updateRequest.Id);
            request.CurrentStatus = updateRequest.CurrentStatus;
            request.LastModifiedBy = updateRequest.LastModifiedBy;
            request.LastModifiedDate = DateTime.Now;

            return requests.Where(x => x.Id == request.Id)
                .Select(y => { y = request; return y; })
                .ToList();
        }
    }
}
