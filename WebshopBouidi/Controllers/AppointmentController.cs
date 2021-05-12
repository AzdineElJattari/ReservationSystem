using System.Web.Mvc;
using WebshopBouidi.BAL.Appointment;
using WebshopBouidi.Models;

namespace WebshopBouidi.Controllers
{
    public class AppointmentController : Controller
    {
        // GET: Appointment
        public ActionResult Index()
        {
            AppointmentModel appointmentModel = new AppointmentModel();
            return View(appointmentModel);
        }

        //POST: Appointment
        [HttpPost]
        public ActionResult Create(AppointmentModel appointment)
        {
            if (ModelState.IsValid)
            {
                AppointmentBAL.CreateAppointment(appointment);
                ViewBag.Msg = "Dankuwel voor het maken van een afspraak!";
                return RedirectToAction("Index", "Appointment");
            }
            return PartialView("Index", appointment);
        }
    }
}