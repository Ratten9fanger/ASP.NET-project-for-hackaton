using Microsoft.AspNetCore.Mvc;

namespace hackaton.Controllers
{
    public class AnswersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
