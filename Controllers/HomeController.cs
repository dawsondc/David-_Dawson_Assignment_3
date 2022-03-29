using David__Dawson_Assignment_3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace David__Dawson_Assignment_3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// index view
        /// </summary>
        /// <returns>redirects the user to the Person view</returns>
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Person");
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
    }
}