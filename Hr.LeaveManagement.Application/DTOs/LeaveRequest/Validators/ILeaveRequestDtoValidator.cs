using FluentValidation;
using Hr.LeaveManagement.Application.Contracts.Persistence;

namespace Hr.LeaveManagement.Application.DTOs.LeaveRequest.Validators
{
    public class ILeaveRequestDtoValidator : AbstractValidator<ILeaveRequestDto>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;

        public ILeaveRequestDtoValidator(ILeaveRequestRepository leaveRequestRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;
        }

        public ILeaveRequestDtoValidator()
        {
            RuleFor(p => p.StartDate)
                .NotNull().WithMessage("{PropertyName} is required")
                .NotEmpty().WithMessage("{PropertyName} is required")
                .LessThanOrEqualTo(p => p.EndDate).WithMessage("{PropertyName} cannot be greater than end date");

            RuleFor(p => p.EndDate)
               .NotNull().WithMessage("{PropertyName} is required")
               .NotEmpty().WithMessage("{PropertyName} is required")
               .GreaterThanOrEqualTo(p => p.EndDate).WithMessage("{PropertyName} cannot be less than start date");

            RuleFor(p => p.LeaveTypeId)
                .GreaterThan(0)
                .MustAsync(async (id, token) =>
                {
                    var exists = await _leaveRequestRepository.Exists(id);
                    return !exists;
                })
                .WithMessage("{PropertyName} value does not exists");
        }
    }
}
