using hackaton.Models; 
using Microsoft.AspNetCore.Mvc;

namespace hackaton.Controllers
{
    public class LogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Reg(User user)
        {
            Console.WriteLine(user.name + "reg");
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Log(User user)
        {
            Console.WriteLine(user.name + "log");
            return RedirectToAction("Index", "Home");
        }
    }
}
