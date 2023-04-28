using Microsoft.AspNetCore.Mvc;

namespace ToDoList.WebApplication.Controllers
{
    public class ToDoListController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
