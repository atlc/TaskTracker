using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

            return RedirectToAction("List", "Tasks");
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var tasks = await dbContext.Tasks.OrderBy(task => task.DueDate).ToListAsync();
            return View(tasks);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid Id)
        {
            var task = await dbContext.Tasks.FindAsync(Id);
            return View(task);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditTaskViewModel task)
        {
            var editableTask = await dbContext.Tasks.FindAsync(task.Id);

            if (editableTask is not null)
            {
                editableTask.Title = task.Title;
                editableTask.Description = task.Description;
                editableTask.CreatedDate = task.CreatedDate;
                editableTask.DueDate = task.DueDate;
                editableTask.Complete = task.Complete;

                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("List", "Tasks");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Models.Entities.Task task)
        {
            var removeableTask = await dbContext.Tasks.AsNoTracking().FirstOrDefaultAsync(t => t.Id == task.Id);

            if (removeableTask is not null)
            {

                dbContext.Tasks.Remove(task);
                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("List", "Tasks");
        }
    }
}
