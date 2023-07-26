using System.Net;
using AssignmentsAPI.Controllers;
using AssignmentsAPI.Models;
using AssignmentsAPI.Services;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace AssignmentsAPI.UnitTests.ControllersTests;

[TestFixture]
public class PostShould
{
    private Mock<IValidator<Assignments>> _mockAssignmentValidator;
    private Mock<IAssignmentsService> _mockAssignmentsService;
    private AssignmentsController _controller;
    
    [SetUp]
    public void Setup()
    {
        _mockAssignmentValidator = new Mock<IValidator<Assignments>>();
        _mockAssignmentsService = new Mock<IAssignmentsService>();

        _controller = new AssignmentsController(_mockAssignmentsService.Object, _mockAssignmentValidator.Object);
    }
    
    [Test]
    public async Task ReturnBadRequestGivenInvalidAssignment()
    {
        _mockAssignmentValidator.Setup(x 
            => x.ValidateAsync(It.IsAny<Assignments>(), default)).ReturnsAsync(new ValidationResult(new List<ValidationFailure>
        {
            new("DueDate", "Due Date is not in correct format or blank")
        }));
        var result = await _controller.Post(new Assignments());
        Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());
    }
    
    [Test]
    public async Task CallsUpdateAsyncSuccessfully()
    {
        var assignment = new Assignments
        {
            ExternalId = Guid.NewGuid().ToString()
        };
        _mockAssignmentValidator.Setup(x 
            => x.ValidateAsync(It.IsAny<Assignments>(), default)).ReturnsAsync(new ValidationResult(new List<ValidationFailure>()));
        
        _mockAssignmentsService.Setup(s => s.UpdateAsync(assignment)).Returns(Task.CompletedTask);
        
        var result = await _controller.Post(assignment);
        
        _mockAssignmentsService.Verify(x => x.UpdateAsync(assignment), Times.Once);
        Assert.That(result, Is.InstanceOf<OkObjectResult>());
    }

    [TestCase(null)]
    [TestCase("")]
    [TestCase("Hi")]
    [TestCase("00000000-0000-0000-0000-000000000000")]
    public async Task CallsInsertAsyncSuccessfully(string externalId)
    {
        var assignment = new Assignments
        {
            ExternalId = externalId
        };
        _mockAssignmentValidator.Setup(x 
            => x.ValidateAsync(It.IsAny<Assignments>(), default)).ReturnsAsync(new ValidationResult(new List<ValidationFailure>()));
        
        _mockAssignmentsService.Setup(s => s.InsertAsync(assignment)).Returns(Task.CompletedTask);
        
        var result = await _controller.Post(assignment);
        
        _mockAssignmentsService.Verify(x => x.InsertAsync(assignment), Times.Once);
        Assert.That(result, Is.InstanceOf<OkObjectResult>());
    }

    [Test]
    public async Task ThrowsExceptionGivenIssueInOneOfTheServices()
    {
        _mockAssignmentValidator.Setup(x 
            => x.ValidateAsync(It.IsAny<Assignments>(), default)).ThrowsAsync(new Exception("Some Error occurred"));
        var result = await _controller.Post(new Assignments());
        
        Assert.That(result, Is.InstanceOf<ObjectResult>());
        Assert.That((result as ObjectResult)?.StatusCode, Is.EqualTo((int)HttpStatusCode.InternalServerError));
    }
}