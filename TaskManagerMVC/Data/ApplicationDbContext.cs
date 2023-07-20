using Microsoft.EntityFrameworkCore;
using TaskManagerMVC.Models;

namespace TaskManagerMVC.Data
{
	public class ApplicationDbContext : DbContext
	{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options)
        {
            
        }

        public DbSet<TaskModel> Tasks { get; set; }
    }
}
