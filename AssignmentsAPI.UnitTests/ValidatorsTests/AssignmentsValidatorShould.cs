using AssignmentsAPI.Models;
using AssignmentsAPI.Validators;
using FluentValidation.TestHelper;
using NUnit.Framework;

namespace AssignmentsAPI.UnitTests.ValidatorsTests;

[TestFixture]
public class AssignmentsValidatorShould
{
    private AssignmentsValidator _validator;

    [SetUp]
    public void Setup()
    {
        _validator = new AssignmentsValidator();
    }
    
    [TestCase("2023-10-01")]
    [TestCase("2023-10-01T00:00:00")]
    [TestCase("2023-10-01T00:00:00.0000000")]
    [TestCase("2023-10-01T00:00:00.0000000Z")]
    [TestCase("2023-10-01T00:00:00.0000000+00:00")]
    [TestCase("2023-10-01T00:00:00.0000000-00:00")]
    [TestCase("2023-10-01T00:00:00.0000000+01:00")]
    [TestCase("2023-10-01T00:00:00.0000000-01:00")]
    [TestCase("2023-10-01T00:00:00.0000000+10:00")]
    [TestCase("2023-10-01T00:00:00.0000000-10:00")]
    public void NotHaveErrorsGivenValidData(string date)
    {
        var assignment = new Assignments
        {
            DueDate = date,
            Description = "Test",
            Assignee = "Test"
        };
        var result = _validator.TestValidate(assignment);
        result.ShouldNotHaveAnyValidationErrors();
    }

    [TestCase("")]
    [TestCase(" ")]
    [TestCase(null)]
    [TestCase("hi")]
    [TestCase("2023-10-01T00:00:00.0000000+")]
    [TestCase("20222-10-01")]
    public void HaveErrorReturnedGivenDueDateIsInvalid(string date)
    {
        var assignment = new Assignments
        {
            DueDate = date,
            Description = "Test",
            Assignee = "Test"
        };
        var result = _validator.TestValidate(assignment);
        result.ShouldHaveValidationErrorFor(c => c.DueDate);
    }
    
    [TestCase("")]
    [TestCase(" ")]
    [TestCase(null)]
    public void HaveErrorReturnedGivenDescriptionIsInvalid(string description)
    {
        var assignment = new Assignments
        {
            DueDate = "2023-10-01",
            Description = description,
            Assignee = "Test"
        };
        var result = _validator.TestValidate(assignment);
        result.ShouldHaveValidationErrorFor(c => c.Description);
    }
    
    [TestCase("")]
    [TestCase(" ")]
    [TestCase(null)]
    public void HaveErrorReturnedGivenAssigneeIsInvalid(string assignee)
    {
        var assignment = new Assignments
        {
            DueDate = "2023-10-01",
            Description = "Test",
            Assignee = assignee
        };
        var result = _validator.TestValidate(assignment);
        result.ShouldHaveValidationErrorFor(c => c.Assignee);
    }
}