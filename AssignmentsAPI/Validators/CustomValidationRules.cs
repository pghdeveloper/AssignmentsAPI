using FluentValidation;

namespace AssignmentsAPI.Validators;

public static class CustomValidationRules
{
    public static IRuleBuilderOptions<T, string> IsValidDate<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder.Must(DateValidator.IsValid);
    }
}