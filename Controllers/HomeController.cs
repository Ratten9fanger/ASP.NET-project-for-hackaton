using hackaton.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using hackaton.ApplicationContext;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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

        public IActionResult Index(Filter filter)
        {

            var query = db.Buses.AsQueryable();

            //if (!string.IsNullOrEmpty(filter.route))
            //{
            //    query = query.Where(b => b.route == filter.route);
            //}

            if (filter.date != null)
            {
                query = query.Where(b => b.date == filter.date);
            }

            //if (!string.IsNullOrEmpty(filter.comfort))
            //{
            //    query = query.Where(b => b.comfort == filter.comfort);
            //}

            //if (!string.IsNullOrEmpty(filter.seats))
            //{
            //    query = query.Where(b => b.seats == filter.seats);
            //}

            //if (filter.conditioner != null)
            //{
            //    query = query.Where(b => b.conditioner == filter.conditioner);
            //}

            //if (filter.trunk != null)
            //{
            //    query = query.Where(b => b.trunk == filter.trunk);
            //}

            //var buses = db.Buses.ToList();
            //var fbuses = query.ToList();

            //foreach (var entity in buses)
            //{
            //    Console.WriteLine(entity.id);
            //}

            //foreach (var entity in fbuses)
            //{
            //    Console.WriteLine("f" + entity.id);
            //}

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
