using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssignmentsAPI.Models;
using AssignmentsAPI.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AssignmentsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AssignmentsController : Controller
    {
        private readonly IAssignmentsService _assignmentsService;

        public AssignmentsController(IAssignmentsService assignmentsService)
        {
            _assignmentsService = assignmentsService;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{externalId}")]
        public async Task<IActionResult> Delete(Guid externalId)
        {
            await _assignmentsService.DeleteAsync(externalId);
            return Ok("Assignment deleted");
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Assignments assignment)
        {
            await _assignmentsService.InsertAsync(assignment);
            return Ok("Assignment inserted");
        }
    }
}

