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

    }

	public interface IAssignmentsRepository
	{
		Task InsertAsync(Assignments assignment);
	}
}

