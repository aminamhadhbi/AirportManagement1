using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.Sockets;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace AM.UI.WEB.Controllers
{
    public class TicketController : Controller
    {
       
    
        private readonly IServiceTicket serviceTicket;

        private readonly IServiceFlight serviceFlight;

        private readonly IServicePassenger servicePassenger;

        public TicketController(IServiceTicket service,IServiceFlight service1, IServicePassenger service2)
        {
            serviceTicket = service;
            serviceFlight = service1;
            servicePassenger = service2;


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

        public ActionResult Details(int id, int FlightId, int TicketNbre)
            {

                //  var Ticket = serviceTicket.GetById(id);
                if ((id == null) || (FlightId == null))

                {
                    return NotFound();
                }
                var Ticket = serviceTicket.GetAll().FirstOrDefault(m => m.PassengerFK == id && m.FlightFK == FlightId && m.TicketNbre == TicketNbre);
            }

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

            var Passenger = servicePassenger.GetAll();
            var Flight = serviceFlight.GetAll();
            ViewBag.FlightFK = new SelectList(Flight, "FlightId", "FlightId");
           ViewBag.PassengerFK = new SelectList(Passenger, "Id", "Id");


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
        public ActionResult Edit(int? id,int? FlightId ,int? TicketNbre )
        {
            if ((id == null)|| (FlightId == null))

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var Ticket = serviceTicket.GetAll().FirstOrDefault(m=>m.PassengerFK == id && m.FlightFK == FlightId && m.TicketNbre == TicketNbre);
         
           
            var Ticket = serviceTicket.GetById(id);
            if (Ticket == null)
            {
                return NotFound();
            }

           /* 
            var Passenger = servicePassenger.GetAll();
            var Flight = serviceFlight.GetAll();
            ViewBag.FlightFK = new SelectList(Flight, "FlightId", "FlightId");
            ViewBag.PassengerFK = new SelectList(Passenger, "Id", "Id");*/

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


                Ticket tick = serviceTicket.GetMany(m => m.PassengerFK == ticket.PassengerFK && m.FlightFK == ticket.FlightFK && m.TicketNbre == ticket.TicketNbre).FirstOrDefault();
                tick.Prix = ticket.Prix;
                tick.Siege = ticket.Siege;
                tick.VIP = ticket.VIP;

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

        public ActionResult Delete(int? id, int? FlightId, int? TicketNbre)
        {
            if ((id == null) || (FlightId == null))

        public ActionResult Delete(int? id)
        {
            if (id == null)

            {
                return NotFound();
            }

            var Ticket = serviceTicket.GetAll().FirstOrDefault(m => m.PassengerFK == id && m.FlightFK == FlightId && m.TicketNbre == TicketNbre);

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

        public ActionResult Delete(int id, int FlightId, int TicketNbre)
        {
            try
            {
                var Ticket = serviceTicket.GetAll().FirstOrDefault(m => m.PassengerFK == id && m.FlightFK == FlightId && m.TicketNbre == TicketNbre);


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
