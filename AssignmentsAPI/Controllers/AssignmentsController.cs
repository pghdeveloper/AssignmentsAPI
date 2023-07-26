using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssignmentsAPI.Models;
using AssignmentsAPI.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AssignmentsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AssignmentsController : Controller
    {
        private readonly IAssignmentsService _assignmentsService;
        private IValidator<Assignments> _validator;

        public AssignmentsController(IAssignmentsService assignmentsService, IValidator<Assignments> validator)
        {
            _assignmentsService = assignmentsService;
            _validator = validator;
        }

        // GET api/values/5
        [HttpGet()]
        public async Task<IActionResult> GetAssignments([FromQuery] string assignee = "")
        {
            try
            {
                var assignments = await _assignmentsService.GetTasksByAssignee(assignee);
                return Ok(assignments);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500, "Internal server error");
            }
        }

        // DELETE api/values/5
        [HttpDelete("{externalId}")]
        public async Task<IActionResult> Delete(Guid externalId)
        {
            try
            {
                await _assignmentsService.DeleteAsync(externalId);
                return Ok("Assignment deleted");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Assignments assignment)
        {
            try
            {
                var result = await _validator.ValidateAsync(assignment);

                if (!result.IsValid) 
                { // re-render the view when validation failed.
                    return BadRequest(result.Errors.Select(e => e.ErrorMessage).ToArray());
                }
                
                if (Guid.TryParse(assignment.ExternalId, out var externalIdResult) && externalIdResult != Guid.Empty)
                {
                    await _assignmentsService.UpdateAsync(assignment);
                    return Ok("Assignment updated");
                }

                await _assignmentsService.InsertAsync(assignment);
                return Ok("Assignment inserted");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}

