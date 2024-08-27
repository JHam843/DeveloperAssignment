using System.Diagnostics;
using DeveloperAssignment.Models;
using Microsoft.AspNetCore.Mvc;

namespace DeveloperAssignment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public int DivideNumbers(int numerator, int denominator)
        {
            try
            {
                return numerator / denominator;
            }
            catch (DivideByZeroException ex)
            {
                // Log the error
                Console.WriteLine($"Error: {ex.Message}");
                return 0;
            }
        }
    }
}
