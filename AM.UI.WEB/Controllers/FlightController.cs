using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AM.UI.WEB.Controllers
{
    public class FlightController : Controller


    {
        private readonly IServiceFlight flightservice;

        public FlightController(IServiceFlight service)
        {
            flightservice = service;
        }


        // GET: FlightController
        public ActionResult Index()
        {
            return View(flightservice.GetAll().ToList());
        }

        // GET: FlightController/Details/5
        public ActionResult Details(int id)
        {

            var flight = flightservice.GetById(id);
            if (flight == null)
            {
                return NotFound();
            }
            return View(flight);
        }

        // GET: FlightController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FlightController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Flight flight)
        {
            try
            {
                flightservice.Add(flight);

                flightservice.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        // GET: FlightController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flight = flightservice.GetById(id);
            if (flight == null)
            {
                return NotFound();
            }
            // ViewBag.flightservice = new SelectList(Enum.GetNames(typeof(FlightType)));
            return View();
        }

        // POST: FlightController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Flight flight)
        {
            try
            {
                flightservice.Update(flight);
                flightservice.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FlightController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flight = flightservice.GetById(id);
            if (flight == null)
            {
                return NotFound();
            }

            return View(flight);
        }

        // POST: FlightController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                var flight = flightservice.GetById(id);
                flightservice.Delete(flight);
                flightservice.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
