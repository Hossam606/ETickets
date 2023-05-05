using eTickets.Interfaces;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    public class CinemasController : Controller
    {
        private readonly IRepository<Cinema> _cinema;
        public CinemasController(IRepository<Cinema> cinema)
        {
            _cinema = cinema;
        }

        public async Task<IActionResult> Index()
        {
            var allProduct = _cinema.GetAll();
            return View(allProduct);
        }

        //Get:Cinemas/Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("PictureUrl,CinemaName,Description")] Cinema cinema) 
        {
            if (ModelState.IsValid)
            {
                await _cinema.Add(cinema);
                return RedirectToAction(nameof(Index));
            }
            return View(cinema);
        }

        //Get:Actors/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var cinema = await _cinema.GetById(id);
            if (cinema == null) return View("NotFound");
            return View(cinema);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CinemaName,PictureUrl,Description")] Cinema cinema)
        {
            if (ModelState.IsValid)
            {
                await _cinema.UpdateAsync(id, cinema);
                return RedirectToAction(nameof(Index));
            }
            return View(cinema);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var cinema = await _cinema.GetById(id);
            if (cinema == null) return View("NotFound");
            return View(cinema);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var cinema = await _cinema.GetById(id);
            if (cinema == null) return View("NotFound");
            await _cinema.Delete(id);
            return RedirectToAction(nameof(Index));

        }
    }
}
