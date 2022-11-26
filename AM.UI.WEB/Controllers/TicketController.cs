using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AM.UI.WEB.Controllers
{
    public class TicketController : Controller
    {
       
    
        private readonly IServiceTicket serviceTicket;

        public TicketController(IServiceTicket service)
        {
            serviceTicket = service;
        }


        // GET: TicketController
        public ActionResult Index()
        {
            return View(serviceTicket.GetAll().ToList());
        }

        // GET: TicketController/Details/5
        public ActionResult Details(int id)
        {

            var Ticket = serviceTicket.GetById(id);
            if (Ticket == null)
            {
                return NotFound();
            }
            return View(Ticket);
        }

        // GET: TicketController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TicketController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Ticket Ticket)
        {
            try
            {
                serviceTicket.Add(Ticket);

                serviceTicket.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        // GET: TicketController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Ticket = serviceTicket.GetById(id);
            if (Ticket == null)
            {
                return NotFound();
            }
            // ViewBag.flightservice = new SelectList(Enum.GetNames(typeof(FlightType)));
            return View();
        }

        // POST: TicketController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Ticket ticket)
        {
            try
            {
                serviceTicket.Update(ticket);
                serviceTicket.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TicketController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Ticket = serviceTicket.GetById(id);
            if (Ticket == null)
            {
                return NotFound();
            }

            return View(Ticket);
        }

        // POST: TicketController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                var Ticket = serviceTicket.GetById(id);
                serviceTicket.Delete(Ticket);
                serviceTicket.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
