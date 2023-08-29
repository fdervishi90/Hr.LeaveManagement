using Hr.LeaveManagement.Application.Contracts.Persistence;
using Hr.LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;

namespace Hr.LeaveManagement.Persistence.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        private readonly LeaveManagementsDbContext _context;

        public LeaveRequestRepository(LeaveManagementsDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? ApprovalStatus)
        {
            leaveRequest.Approved = ApprovalStatus;
            _context.Entry(leaveRequest).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public Task<List<LeaveRequest>> GetLeaveRequestsWithDetails()
        {
            var leaveRequests = _context.LeaveRequests.Include(l => l.LeaveType).ToListAsync();
            return leaveRequests;
        }

        public Task<List<LeaveRequest>> GetLeaveRequestsWithDetails(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<LeaveRequest> GetLeaveRequestWithDetails(int id)
        {
            var leaveRequest = await _context.LeaveRequests.Include(l => l.LeaveType).FirstOrDefaultAsync(l => l.Id == id);
            return leaveRequest;
        }
    }
}
