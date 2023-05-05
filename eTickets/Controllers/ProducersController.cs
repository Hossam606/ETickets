using eTickets.Interfaces;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    public class ProducersController : Controller
    {
        private readonly IRepository<Producer> _producer;


        public ProducersController(IRepository<Producer> producer)
        {
            _producer = producer;

        }
        public async Task<IActionResult> Index()
        {
            var producer = _producer.GetAll();
            return View(producer);
        }

        //Get:Producer/Create
        public IActionResult Create()
        {
            return View();
        }

        //Post:Producer/Create
        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProducerName,PictureUrl,Bio")] Producer producer)
        {
            if (ModelState.IsValid)
            {
                await _producer.Add(producer);
                return RedirectToAction(nameof(Index));
            }
            return View(producer);
        }
        //Get:Producer/Details
        public async Task<IActionResult> Details(int id)
        {
            var producerDetails = await _producer.GetById(id);
            if (producerDetails == null) return View("NotFound");
            return View(producerDetails);
        }

        //Get:Producer/Edit
        public async Task<IActionResult> Edit(int id)
        {
            var producerDetails = await _producer.GetById(id);
            if (producerDetails == null) return View("NotFound");
            return View(producerDetails);
        }

        //Post:Producer/Edit  [Bind("ProducerId,ProducerName,PictureUrl,Bio")]
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProducerName,PictureUrl,Bio")] Producer producer)
        {
            if (ModelState.IsValid)
            {
                await _producer.UpdateAsync(id, producer);
                return RedirectToAction(nameof(Index));
            }
            return View(producer);
        }


        //Get:Producer/Delete
        public async Task<IActionResult> Delete(int id)
        {
            var producerDetails = await _producer.GetById(id);
            if (producerDetails == null) return View("NotFound");
            return View(producerDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actorDetails = await _producer.GetById(id);
            if (actorDetails == null) return View("NotFound");
            await _producer.Delete(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
