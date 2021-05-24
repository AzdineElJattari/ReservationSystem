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
            ViewModel vm = new ViewModel();
            AppointmentModel appointmentModel = new AppointmentModel();
            DateTimeModel dateTimeModel = new DateTimeModel();
            vm.AppointmentModel = appointmentModel;
            vm.DateTimeModel = dateTimeModel;
            return View(vm);
        }

        //POST: Appointment
        [HttpPost]
        public async Task<ActionResult> Create(ViewModel appointment)
        {
            if (ModelState.IsValid)
            {
                var body = $"<p>Beste {appointment.AppointmentModel.CustomerName}, </p><p>Uw afspraak voor {appointment.AppointmentModel.AppointmentDate} is succesvol vastgesteld. Gelieve zeker een mondmasker mee te nemen en 15 minuten op voorhand aan te komen op locatie!</p><br/><p>Met vriendelijke groet,</p><br/><p>Kapper Bouidi</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress(appointment.AppointmentModel.Email));
                message.From = new MailAddress("testmail.bouidi@gmail.com");
                message.Subject = $"Afspraak bevestiging {appointment.AppointmentModel.AppointmentDate}";
                message.Body = string.Format(body);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(System.Configuration.ConfigurationManager.AppSettings["FromEmail"], System.Configuration.ConfigurationManager.AppSettings["FromPassword"]);
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);

                    //Concatenate chosen appointment date & time together
                    string finalDate = $"{appointment.AppointmentModel.AppointmentDate} - {appointment.ChosenAppointmentTime}";
                    appointment.AppointmentModel.AppointmentDate = finalDate;
                    AppointmentBAL.CreateAppointment(appointment.AppointmentModel); //STOPPED HERE BECAUSE CANNOT RUN MIGRATION BECAUSE AZURE CREDENTIALS (AUTH) NOT LETTING ME IN
                    return RedirectToAction("Index", "Appointment");
                }
            }
            return PartialView("Index", appointment);
        }
    }
}