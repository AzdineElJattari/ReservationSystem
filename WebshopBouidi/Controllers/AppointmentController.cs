using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
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
        public async Task<ActionResult> Create(AppointmentModel appointment) //DUBBLE CHECK
        {
            if (ModelState.IsValid)
            {
                var body = $"<p>Beste {appointment.CustomerName}, </p><p>Uw afspraak voor {appointment.AppointmentDate.ToString("g")} is succesvol vastgesteld. Gelieve zeker een mondmasker mee te nemen en 15 minuten op voorhand aan te komen op locatie!</p><br/><p>Met vriendelijke groet,</p><br/><p>Kapper Bouidi</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress(appointment.Email));
                message.From = new MailAddress("testmail.bouidi@gmail.com");
                message.Subject = $"Afspraak bevestiging {appointment.AppointmentDate.ToString("g")}";
                message.Body = string.Format(body);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(System.Configuration.ConfigurationManager.AppSettings["FromEmail"], System.Configuration.ConfigurationManager.AppSettings["FromPassword"]);
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);
                    AppointmentBAL.CreateAppointment(appointment);
                    ViewBag.Msg = "Dankuwel voor het maken van een afspraak!";
                    return RedirectToAction("Index", "Appointment");
                }
            }
            return PartialView("Index", appointment);
        }
    }
}