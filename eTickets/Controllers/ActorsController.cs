using eTickets.Interfaces;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    public class ActorsController : Controller 
    {
        private readonly IRepository<Actor> _actors;
        public ActorsController(IRepository<Actor> actors)
        {
            _actors = actors;
        }
        public async Task<IActionResult> Index()
        {
            var actor = _actors.GetAll();
            return View(actor);
        }
        // Get:Actors/Create
        public IActionResult Create()
        {
            return View();
        }
        // Post:Actors/Create
        [HttpPost]
        public async Task<IActionResult> Create([Bind("ActorName,PictureUrl,Bio")] Actor actor)
        {
            if (ModelState.IsValid)
            {
                await _actors.Add(actor);
                return RedirectToAction(nameof(Index));
            }
            return View(actor);
        }

        //Get:Actors/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var actorDetails = await _actors.GetById(id);

            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }
        //Get:Actors/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var actorDetails = await _actors.GetById(id);
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ActorName,PictureUrl,Bio")] Actor actor)
        {
            if (ModelState.IsValid)
            {
                await _actors.UpdateAsync(id, actor);
                return RedirectToAction(nameof(Index));
            }
            return View(actor);
        }

        //Get:Actors/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var actorDetails = await _actors.GetById(id);
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actorDetails = await _actors.GetById(id);
            if (actorDetails == null) return View("NotFound");
            await _actors.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
