using hackaton.ApplicationContext;
using hackaton.Models; 
using Microsoft.AspNetCore.Mvc;

namespace hackaton.Controllers
{
    public class LogController : Controller
    {
        ApplicationDBContext db;

        public LogController(ApplicationDBContext context)
        {
            db = context;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Reg(string name, string password, string repeatPassword)
        {
            if (password != repeatPassword)
            {
                // Обработка ошибки: пароли не совпадают
                ModelState.AddModelError("", "Пароли не совпадают.");
                return View("Index");
            }

            User user = new User
            {
                name = name,
                password = password
            };

            db.Users.Add(user);
            await db.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public IActionResult Log(string name, string password)
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
