using System.ComponentModel.DataAnnotations;

namespace TaskManagerMVC.Models
{
	public class TaskModel
	{
		[Key]
		public int Id { get; set; }

		[MaxLength(50)]
		[Required]
		public string Name { get; set; }

		public string? Description { get; set; }
	}
}
