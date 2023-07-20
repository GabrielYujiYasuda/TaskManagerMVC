using Microsoft.AspNetCore.Mvc;
using TaskManagerMVC.Data;
using TaskManagerMVC.Models;

namespace TaskManagerMVC.Controllers
{
	public class TaskController : Controller
	{
		//Create the DB connection
		private readonly ApplicationDbContext _context;
        public TaskController(ApplicationDbContext context)
        {
			_context = context;
        }

        public IActionResult Index()
		{
			List<TaskModel> taskList = _context.Tasks.ToList();

			return View(taskList);
		}
	}
}
