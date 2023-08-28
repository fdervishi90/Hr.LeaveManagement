﻿using Hr.LeaveManagement.Application.DTOs.LeaveAllocation;
using MediatR;

namespace Hr.LeaveManagement.Application.Features.LeaveAllocations.Requests.Queries
{
    public class GetLeaveAllocationDetailRequest : IRequest<LeaveAllocationDto>
    {
        public int Id { get; set; }
    }
}
