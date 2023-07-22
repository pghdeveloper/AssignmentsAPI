using System;
namespace AssignmentsAPI.Models
{
	public class Assignments
	{
		public Guid Id { get; set; }
		public string Assignee { get; set; }
		public string DueDate { get; set; }
		public string Description { get; set; }
		public decimal PercentCompleted { get; set; }
		public bool IsPriority { get; set; }
	}
}

