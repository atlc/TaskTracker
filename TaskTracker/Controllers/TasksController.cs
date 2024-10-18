using Microsoft.AspNetCore.Mvc;

namespace TaskTracker.Controllers
{
    public class TasksController : Controller
    {
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
    }
}
