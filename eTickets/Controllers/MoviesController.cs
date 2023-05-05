using eTickets.Interfaces;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
     
    public class MoviesController : Controller
    {
        private readonly IRepository<Movie> _movie;
        public MoviesController(IRepository<Movie> movie)
        {
            _movie = movie;
        }
        //public IActionResult HomePage() 
        //{
        //    var allcinema = _movie.GetAll(new string[] { "Cinema" });
            
        //    return View(allcinema);
        //}
        public IActionResult Index()
        {
            var allcinema = _movie.GetAll();
            return View(allcinema);
        }

        // Get:Actors/Create
        public IActionResult Create()
        {
            return View();
        }
        // Post:Actors/Create
        [HttpPost]
        public async Task<IActionResult> Create([Bind("TitleMovie,Description,Price,ImageUrl,StartDate,EndDate,MoviesCategory,Actors")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                await _movie.Add(movie);
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }
    }
}
