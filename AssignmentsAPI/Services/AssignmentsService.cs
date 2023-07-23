using System;
using AssignmentsAPI.Models;
using AssignmentsAPI.Repositories;

namespace AssignmentsAPI.Services
{
	public class AssignmentsService : IAssignmentsService
	{
		private readonly IAssignmentsRepository _assignmentsRepository;

		public AssignmentsService(IAssignmentsRepository assignmentsRepository)
		{
			_assignmentsRepository = assignmentsRepository;
		}

		public async Task InsertAsync(Assignments assignment)
		{
			assignment.ExternalId = Guid.NewGuid().ToString();
			await _assignmentsRepository.InsertAsync(assignment); 
		}
		
		public async Task DeleteAsync(Guid externalId)
		{
			await _assignmentsRepository.DeleteAsync(externalId);
		}
		
		public async Task<IEnumerable<Assignments>> GetTasksByAssignee(string assignee)
		{
			return await _assignmentsRepository.GetTasksByAssignee(assignee);
		}

		public async Task UpdateAsync(Assignments assignment)
		{
			await _assignmentsRepository.UpdateAsync(assignment);
		}
	}

	public interface IAssignmentsService
	{
		Task InsertAsync(Assignments assignment);
		Task DeleteAsync(Guid externalId);
		Task<IEnumerable<Assignments>> GetTasksByAssignee(string assignee);
		Task UpdateAsync(Assignments assignment);
	}
}

