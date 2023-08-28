using Hr.LeaveManagement.Domain.Common;

namespace Hr.LeaveManagement.Application.Persistence.Contracts
{
    public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
    {
        // If there are specific methods that are needed for the LeaveAllocation you can create them in here

        Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id);
        Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails(int id);
    }
}
