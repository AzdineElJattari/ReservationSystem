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
            AppointmentBAL.CreateAppointment(appointment);
            return RedirectToAction("Index", "Appointment");
        }
    }
}