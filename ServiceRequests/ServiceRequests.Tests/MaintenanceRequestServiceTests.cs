using MaintenanceRequests.Dtos;
using MaintenanceRequests.Services;
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
        public void Test2DeleteMaintenanceRequestById_CheckIfElementIsDeleted_ReturnsTrue()
        {
            var requests = _maintenanceRequestService.GetAllMaintenanceRequests();
            var idOfDeletedElement = requests[0].Id;

            _maintenanceRequestService.DeleteMaintenanceRequestById(idOfDeletedElement);

            var doesElementExists = _maintenanceRequestService.GetMaintenanceRequestById(idOfDeletedElement) != null;

            Assert.False(doesElementExists, "Element should not exist after beeing deleted."); ;
        }

        [Fact]
        public void Test3CreateNewMaitenanceRequest_CheckIfElementIsAdded_ReturnsTrue()
        {
            var numberOfElementsBeforeAddingNew = _maintenanceRequestService.GetAllMaintenanceRequests().Count;

            var addrequest = new AddMaintenanceRequestDto
            {
                BuildingCode = "COH",
                Description = "Please turn up the AC in suite 1200D. It is too hot here.",
                CreatedBy = "Nik Patel"
            };

            var numberOfElementsAfterAddingNew = _maintenanceRequestService.CreateNewMaintenanceRequest(addrequest).Count;

            Assert.True(numberOfElementsBeforeAddingNew < numberOfElementsAfterAddingNew, 
                "Number or elements should increase after we add new element"); ;
        }
    }
}
