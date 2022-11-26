using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AM.UI.WEB.Controllers
{
    public class PassengerController : Controller
    {
        private readonly IServicePassenger servicePassenger;

        public PassengerController(IServicePassenger service)
        {
            servicePassenger = service;
        }

        // GET: PassengerController
        public ActionResult Index()
        {
            return View(servicePassenger.GetAll().ToList());
        }

        // GET: PassengerController/Details/5
        public ActionResult Details(int id)
        {

            var Passenger = servicePassenger.GetById(id);
            if (Passenger == null)
            {
                return NotFound();
            }
            return View(Passenger);
        }

        // GET: PassengerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PassengerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Passenger Passenger)
        {
            try
            {
                servicePassenger.Add(Passenger);

                servicePassenger.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        // GET: PassengerController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Passenger = servicePassenger.GetById(id);
            if (Passenger == null)
            {
                return NotFound();
            }
            // ViewBag.flightservice = new SelectList(Enum.GetNames(typeof(FlightType)));
            return View();
        }

        // POST: PassengerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Passenger Passenger)
        {
            try
            {
                servicePassenger.Update(Passenger);
                servicePassenger.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PassengerController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Passenger = servicePassenger.GetById(id);
            if (Passenger == null)
            {
                return NotFound();
            }

            return View(Passenger);
        }

        // POST: PassengerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                var Passenger = servicePassenger.GetById(id);
                servicePassenger.Delete(Passenger);
                servicePassenger.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
