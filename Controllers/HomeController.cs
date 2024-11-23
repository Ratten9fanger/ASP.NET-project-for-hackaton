using hackaton.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using hackaton.ApplicationContext;

namespace hackaton.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDBContext db;

        public HomeController(ApplicationDBContext context)
        {
            db = context;
        }

        private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
            var userEntities = db.Buses.ToList();

            foreach (var entity in userEntities)
            {
                Console.WriteLine(entity.id);
            }

            return View();

        }

        public IActionResult Filter(Filter filter)
        {
            Console.WriteLine($"{filter.route}, {filter.date}, {filter.comfort}, {filter.seats}, {filter.trunk}, {filter.conditioner},");
            return RedirectToAction("Index");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
