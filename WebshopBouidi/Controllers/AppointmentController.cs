using System.Web.Mvc;
using WebshopBouidi.Models;

namespace WebshopBouidi.Controllers
{
    public class AppointmentController : Controller
    {

        // GET: Appointment
        public ActionResult Index()
        {
            DateTimeBinder dateTimeBinder = new DateTimeBinder();
            return View(dateTimeBinder);
        }
    }
}