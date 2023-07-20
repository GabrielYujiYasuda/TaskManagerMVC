using Microsoft.AspNetCore.Mvc;
using TaskManagerMVC.Data;
using TaskManagerMVC.Models;

//GET ALL - done

//GET ONE TO CREATE - done
//CREATE - done

//GET ONE TO DELETE - done
//DELETE - done

//GET ONE DO DELETE
//UPDATE


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

		//GET ALL
        public IActionResult Index()
		{
			List<TaskModel> taskList = _context.Tasks.ToList();

			return View(taskList);
		}

		//GET ONE TO CREATE
		public IActionResult Create()
		{
			return View();
		}

		//CREATE
		[HttpPost]
		public IActionResult Create(TaskModel task)
		{
			if (ModelState.IsValid)
			{
				_context.Tasks.Add(task);
				_context.SaveChanges();

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

			return RedirectToAction("Index");
		}
	}
}
