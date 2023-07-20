using Microsoft.AspNetCore.Mvc;
using TaskManagerMVC.Data;
using TaskManagerMVC.Models;

namespace TaskManagerMVC.Controllers
{
	public class TaskController : Controller
	{
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

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(TaskModel task)
		{
			if (ModelState.IsValid)
			{
				_context.Tasks.Add(task);
				_context.SaveChanges();

				TempData["success"] = "Category created successfully";

				return RedirectToAction("Index");
			}

			return View();
		}

		public IActionResult Update(int? id)
		{
			TaskModel taskChosenToUpdate = _context.Tasks.FirstOrDefault(x => x.Id == id);

			if (id == 0 || id == null || taskChosenToUpdate == null)
			{
				return NotFound();
			}

			return View(taskChosenToUpdate);
		}

		[HttpPost]
		public IActionResult Update(TaskModel task)
		{
			if (ModelState.IsValid)
			{
				_context.Tasks.Update(task);
				_context.SaveChanges();

				TempData["success"] = "Category updated successfully";

				return RedirectToAction("Index");
			}

			return View();
		}

		public IActionResult Delete(int? id)
		{
			TaskModel taskChosenDelete = _context.Tasks.FirstOrDefault(x => x.Id == id);

			if (id == 0 || id == null || taskChosenDelete == null)
			{
				return NotFound();
			}

			return View(taskChosenDelete);
		}

		[HttpPost, ActionName("Delete")]
		public IActionResult DeletePOST(int? id)
		{
			TaskModel task = _context.Tasks.Find(id);

			if (task == null)
			{
				return NotFound();
			}

			_context.Tasks.Remove(task);
			_context.SaveChanges();

			TempData["success"] = "Category deleted successfully";

			return RedirectToAction("Index");
		}
	}
}
