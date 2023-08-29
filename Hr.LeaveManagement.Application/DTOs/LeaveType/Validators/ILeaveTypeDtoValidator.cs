using FluentValidation;

namespace Hr.LeaveManagement.Application.DTOs.LeaveType.Validators
{
    public class ILeaveTypeDtoValidator : AbstractValidator<ILeaveTypeDto>
    {
        public ILeaveTypeDtoValidator()
        {
            RuleFor(p => p.Name)
              .NotEmpty().WithMessage("{PropertyName} is required")
              .NotNull()
              .MaximumLength(100).WithMessage("{PropertyName} max length is {ComparisonValue} characters")
              .MinimumLength(5).WithMessage("{PropertyName} min length is {ComparisonValue} characters");

            RuleFor(p => p.DefaultDays)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .GreaterThan(0).WithMessage("{PropertyName} cannot be {ComparisonValue}")
                .LessThanOrEqualTo(20).WithMessage("{PropertyName} max length is {ComparisonValue} days");
        }
    }
}
