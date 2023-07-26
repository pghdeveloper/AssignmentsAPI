using AssignmentsAPI.Models;
using FluentValidation;

namespace AssignmentsAPI.Validators;

public class AssignmentsValidator : AbstractValidator<Assignments>
{
    public AssignmentsValidator()
    {
        RuleFor(x => x.DueDate).IsValidDate().WithMessage("Due Date is not in correct format or blank");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required");
        RuleFor(x => x.Assignee).NotEmpty().WithMessage("Assignee is required for sure");
    }
}