namespace Hr.LeaveManagement.Application.DTOs.LeaveType
{
    public interface ILeaveTypeDto
    {
        int DefaultDays { get; set; }
        string Name { get; set; }
    }
}