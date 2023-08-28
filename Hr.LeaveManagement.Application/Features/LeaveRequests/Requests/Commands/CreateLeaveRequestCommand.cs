﻿using Hr.LeaveManagement.Application.DTOs.LeaveRequest;
using MediatR;

namespace Hr.LeaveManagement.Application.Features.LeaveRequests.Requests.Commands
{
    public class CreateLeaveRequestCommand : IRequest<int>
    {
        public LeaveRequestDto LeaveRequestDto { get; set; }
    }
}
