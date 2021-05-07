using System;
using System.Web.Mvc;
using WebshopBouidi.Models;

namespace WebshopBouidi.Controllers
{
    public class AppointmentController : Controller
    {
        // GET: Appointment
        public ActionResult Index()
        {
            DateTimeModel dateTimeModel = new DateTimeModel();
            dateTimeModel.Date = DateTime.Now;
            return View(dateTimeModel);
        }

        //POST: Appointment
        [HttpPost]
        public ActionResult Index(AppointmentModel appointment)
        {
            return View();
        }
    }
}