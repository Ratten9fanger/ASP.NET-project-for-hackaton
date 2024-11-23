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
        bool isSecondTime = false;

        public HomeController(ApplicationDBContext context)
        {
            db = context;
        }

        private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index(Filter filter, bool isSecondTime = false)
        {

            var model = new BusWithFilter 
            {
                filter = filter,
                buses = new List<Bus>() // Изначально пустой список автобусов
            };

            var query = db.Buses.AsQueryable();

            if (isSecondTime)
            {
                //if (!string.IsNullOrEmpty(filter.route))
                //{
                //    query = query.Where(b => b.route == filter.route);
                //}

                //if (filter.date != null)
                //{
                //    query = query.Where(b => b.date == filter.date);
                //}

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

                model.buses = query.ToList();


            }

            return View(model);

        }

        [HttpPost]
        public void busSelectionForm(List<int> selectedBuses)
        {
            if (selectedBuses == null || selectedBuses.Count == 0)
            {
                // Обработка случая, когда список пуст
                // Например, можно выбросить исключение или просто вернуть
                // Или можно просто вернуть, если не хотите выбрасывать исключение
                Response.WriteAsync("<script>alert('Please select atleast 1 bus');</script>");

                return;
            }

            var query = db.Buses.AsQueryable();

            var tgNamesList = new List<string>();

            foreach (var num in selectedBuses)
            {
                var bus = query.FirstOrDefault(b => b.id == num);

                if (bus != null)
                {
                    tgNamesList.Add(bus.tg_name);
                }
                else
                {
                    // Обработка случая, когда автобус с данным id не найден
                    Console.WriteLine($"Автобус с id {num} не найден.");
                    // Вы можете также добавить сообщение в tgNamesList или выполнить другую логику
                }
            }
        }





        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
