using eTickets.Interfaces;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace eTickets.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository<Movie> _movie;
        public HomeController(ILogger<HomeController> logger,IRepository<Movie> movie)
        {
            _logger = logger;
            _movie=movie;
        }

        public IActionResult Index()
        {
            var allcinema = _movie.GetAll(new string[] { "Cinema","Producer" });

            return View(allcinema);
        }
        public async Task<IActionResult> Details(int id)
        {
            var movieDetails =await _movie.GetById(id);
            if (movieDetails == null) return View("NotFound");
            return View(movieDetails);
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