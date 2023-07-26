using System.Text.Json.Serialization;
using Dapper.Contrib.Extensions;

namespace AssignmentsAPI.Models
{
	[Serializable]
	[Table("Assignments")]
	public class Assignments
	{
		[Key]
		[JsonIgnore]
		public int Id { get; set; }

		public string ExternalId { get; set; } = "";
		public string DueDate { get; set; }
		public string Description { get; set; }
		public decimal? PercentComplete { get; set; }
		public bool? IsPriority { get; set; }
		public string Assignee { get; set; }
	}
}

