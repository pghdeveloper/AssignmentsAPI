using Microsoft.Data.Sqlite;
using System.Data.Common;

namespace AssignmentsAPI.Repositories 
{
	public class SqlConnectionFactory : ISqlConnectionFactory
    {
		public string ConnectionString { get; }

		public SqlConnectionFactory(IConfiguration configuration)
		{
			ConnectionString = configuration.GetConnectionString("WebApiDatabase");
		}

		public DbConnection CreateSqlConnection()
		{
			return new SqliteConnection(ConnectionString);
		}

	}

	public interface ISqlConnectionFactory
	{
		string ConnectionString { get; }
		DbConnection CreateSqlConnection();
	}
}

