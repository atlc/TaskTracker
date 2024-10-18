using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Numerics;
using TaskTracker.Data;
using TaskTracker.Models;

namespace TaskTracker.Controllers
{
    public class TasksController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public TasksController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddTaskViewModel task)
        {
            var newTask = new Models.Entities.Task
            {
                Title = task.Title,
                Description = task.Description,
                CreatedDate = task.CreatedDate,
                DueDate = task.DueDate,
                Complete = task.Complete
            };


            await dbContext.Tasks.AddAsync(newTask);
            await dbContext.SaveChangesAsync();

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {

        }
    }
}
