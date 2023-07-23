using AssignmentsAPI.Models;
using Dapper;
using Dapper.Contrib.Extensions;
using System.Data.SQLite;

namespace AssignmentsAPI.Repositories
{
	public class AssignmentsRepository : IAssignmentsRepository
	{
		private readonly ISqlConnectionFactory _sqlConnectionFactory;

		public AssignmentsRepository(ISqlConnectionFactory sqlConnectionFactory)
		{
			_sqlConnectionFactory = sqlConnectionFactory;
		}

        public async Task InsertAsync(Assignments assignment)
        {
			using (var connection = _sqlConnectionFactory.CreateSqlConnection())
			{
				await connection.InsertAsync(assignment);
			}
        }

        public async Task DeleteAsync(Guid externalId)
        {
	        using (var connection = _sqlConnectionFactory.CreateSqlConnection())
	        {
		        const string sql = @"DELETE FROM Assignments WHERE ExternalId = @externalId";
		        await connection.ExecuteAsync(sql, new { externalId });
	        }
        }

        public async Task<IEnumerable<Assignments>> GetTasksByAssignee(string assignee)
		{
	        using (var connection = _sqlConnectionFactory.CreateSqlConnection())
	        {
		        const string sql = @"SELECT * FROM Assignments WHERE Assignee = @assignee";
		        return await connection.QueryAsync<Assignments>(sql, new { assignee });
	        }
		}
        
        public async Task UpdateAsync(Assignments assignment)
		{
	        using (var connection = _sqlConnectionFactory.CreateSqlConnection())
	        {
		        const string sql = @"
	            UPDATE Assignments 
	            SET Assignee = @Assignee,
	                DueDate = @DueDate,
	                Description = @Description, 
	                PercentComplete = @PercentComplete, 
	                IsPriority = @IsPriority
	            WHERE ExternalId = @ExternalId";	
		        //await connection.ExecuteAsync(sql, new { assignment.Assignee, assignment.DueDate, assignment.Description, assignment.PercentComplete, assignment.IsPriority, assignment.ExternalId });
		        await connection.ExecuteAsync(sql, assignment);
	        }
		}
	}

	public interface IAssignmentsRepository
	{
		Task InsertAsync(Assignments assignment);
		Task DeleteAsync(Guid externalId);
		Task<IEnumerable<Assignments>> GetTasksByAssignee(string assignee);
		Task UpdateAsync(Assignments assignment);
	}
}

