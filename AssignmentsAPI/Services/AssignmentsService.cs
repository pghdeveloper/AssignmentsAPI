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
			assignment.ExternalId = Guid.NewGuid();
			await _assignmentsRepository.InsertAsync(assignment); 
		}
		
		public async Task DeleteAsync(Guid externalId)
		{
			await _assignmentsRepository.DeleteAsync(externalId);
		}
	}

	public interface IAssignmentsService
	{
		Task InsertAsync(Assignments assignment);
		Task DeleteAsync(Guid externalId);
	}
}

