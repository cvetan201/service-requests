using MaintenanceRequests.Models;
using MaintenanceRequests.Services;
using System;
using Xunit;

namespace ServiceRequests.Tests
{
    public class MaintenanceRequestServiceTests
    {
        private readonly IMaintenanceRequestService _maintenanceRequestService = new MaintenanceRequestService();

        [Fact]
        public void Test1GetAllMaintenanceRequests_CheckIfElementsNumberIsGreatherThanOrEqualToOne_ReturnsTrue()
        {
            var requests = _maintenanceRequestService.GetAllMaintenanceRequests();
            Assert.True(requests != null && requests.Count >= 1, "Initially list should contain at least 1 elements."); ;
        }

        [Fact]
        public void Test2DeleteMainteanceRequestById_CheckIfElementIsDeleted_ReturnsTrue()
        {
            var requests = _maintenanceRequestService.GetAllMaintenanceRequests();
            var result = _maintenanceRequestService.DeleteMainteanceRequestById(requests[0].Id);

            Assert.True(requests != null && result.Count == 0, "Deleting the first element then we should have 0 elements."); ;
        }

        [Fact]
        public void Test3CreateNewMaitenanceRequest_CheckIfElementIsAdded_ReturnsTrue()
        {
            var request = new MaintenanceRequest
            {
                Id = new Guid(),
                BuildingCode = "COH",
                Description = "Please turn up the AC in suite 1200D. It is too hot here.",
                CurrentStatus = ServiceStatus.Created,
                CreatedBy = "Nik Patel",
                CreatedDate = DateTime.Now,
                LastModifiedBy = "Jane Doe",
                LastModifiedDate = DateTime.Now
            };

            var requests = _maintenanceRequestService.CreateNewMaitenanceRequest(request);

            Assert.True(requests != null && requests.Count == 2, "Adding one more element now we should have 2 elements."); ;
        }
    }
}
