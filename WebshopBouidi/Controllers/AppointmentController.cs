using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebshopBouidi.BAL.Appointment;
using WebshopBouidi.DAL;
using WebshopBouidi.Models;

namespace WebshopBouidi.Controllers
{
    public class AppointmentController : Controller
    {
        private static List<string> ListOfAppointmentDates { get; set; }
        private static string OldSelectedDate { get; set; }
        private ViewModel vm { get; set; } = new ViewModel();

        // GET: Appointment
        public async Task<ActionResult> Index()
        {
            using (var dbContext = new ProjectContext())
            {
                await Task.Run(() => ListOfAppointmentDates = AppointmentBAL.GetAppointments().Select(x => x.AppointmentDate).ToList());
            }

            if (OldSelectedDate == null)
            {
                AppointmentTimeStatic.FindTimesAndRemove(ListOfAppointmentDates, DateTime.Now.ToString("yyyy/MM/dd"));
                OldSelectedDate = DateTime.Now.ToString("yyyy/MM/dd");
            }
            return View(vm);
        }

        //POST: Get selected date for Appointment
        [HttpPost]
        public async Task<ActionResult> SetSelectedDate(string date)
        {
            var result = date != null ? Content("Responsecode: 200 OK") : Content("Responsecode: 404 ERROR");
            string formattedDate = date.Replace("-", "/");

            if (OldSelectedDate != formattedDate)
            {
                await Task.Run(() => AppointmentTimeStatic.ResetTimeList());
                await Task.Run(() => AppointmentTimeStatic.FindTimesAndRemove(ListOfAppointmentDates, formattedDate));
                OldSelectedDate = date;
            }
            else
            {
                await Task.Run(() => AppointmentTimeStatic.FindTimesAndRemove(ListOfAppointmentDates, formattedDate));
            }
            return result;
        }

        //POST: Appointment
        [HttpPost]
        public async Task<ActionResult> Create(ViewModel appointment)
        {
            string time;

            if (appointment.ChosenAppointmentTime == null)
            {
                time = appointment.DateTimeModel.OpeningTimes.ToList()[0].Text;
            }
            else
            {
                time = appointment.ChosenAppointmentTime;
            }

            _ = time;
            //Concatenate chosen appointment date & time together
            string finalDate = $"{appointment.AppointmentModel.AppointmentDate} - {time}";

            if (ModelState.IsValid)
            {
                var body = $"<p>Beste {appointment.AppointmentModel.CustomerName}, </p><p>Uw afspraak voor {appointment.AppointmentModel.AppointmentDate} om {time} is succesvol vastgesteld. Gelieve zeker een mondmasker mee te nemen en 15 minuten op voorhand aan te komen op locatie!</p><br/><p>Met vriendelijke groet,</p><br/><p>Kapper Bouidi</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress(appointment.AppointmentModel.Email));
                message.From = new MailAddress("testmail.bouidi@gmail.com");
                message.Subject = $"Bevestiging afspraak - {appointment.AppointmentModel.AppointmentDate}";
                message.Body = string.Format(body);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(System.Configuration.ConfigurationManager.AppSettings["FromEmail"], System.Configuration.ConfigurationManager.AppSettings["FromPassword"]);
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);

                    appointment.AppointmentModel.AppointmentDate = finalDate;
                    await Task.Run(() => AppointmentBAL.CreateAppointment(appointment.AppointmentModel));
                    await Task.Run(() => AppointmentTimeStatic.FindTimesAndRemove(ListOfAppointmentDates, OldSelectedDate));
                    _ = appointment;
                    _ = vm;
                    ViewBag.Saved = "Saved";
                    //return RedirectToAction("Home", "Home");
                }
            }
            return RedirectToAction("Home", "Home");
            //return View("~/Views/Appointment/Index.cshtml");
        }
    }
}