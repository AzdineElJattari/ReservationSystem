using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private static string SelectedDate { get; set; }
        private ViewModel VM { get; set; } = new ViewModel();
        private string DateOfToday { get; } = DateTime.Now.ToString("yyyy/MM/dd");

        public async Task<ActionResult> Index()
        {
            _ = VM;
            _ = SelectedDate;
            using (var dbContext = new ProjectContext())
            {
                await Task.Run(() => ListOfAppointmentDates = AppointmentBAL.GetAppointments().Select(x => x.AppointmentDate).ToList());
            }

            if (SelectedDate == null)
            {
                VM.DateTimeModel.FindTimesAndRemove(ListOfAppointmentDates, DateOfToday);
                SelectedDate = DateOfToday;
            }
            else if (SelectedDate == DateOfToday)
            {
                VM.DateTimeModel.FindTimesAndRemove(ListOfAppointmentDates, DateOfToday);
            }
            else if (SelectedDate != null && SelectedDate != DateOfToday)
            {
                VM.DateTimeModel.FindTimesAndRemove(ListOfAppointmentDates, SelectedDate);
            }
            ModelState.Clear();
            return View(VM);
        }

        public ActionResult SetSelectedDate(string date)
        {
            //var result = date != null ? Content("Responsecode: 200 OK") : Content("Responsecode: 404 ERROR");
            string formattedDate = date.Replace("-", "/");
            if (SelectedDate != formattedDate)
            {
                VM.DateTimeModel.ResetTimeList();
                VM.DateTimeModel.FindTimesAndRemove(ListOfAppointmentDates, formattedDate);
                SelectedDate = date;
            }
            else
            {
                VM.DateTimeModel.FindTimesAndRemove(ListOfAppointmentDates, formattedDate);
            }
            _ = VM;
            _ = SelectedDate;
            ModelState.Clear();

            return RedirectToAction("Index", "Appointment");
        }

        //POST: Appointment
        [HttpPost]
        public async Task<ActionResult> Create(ViewModel appointment)
        {
            string time;

            if (appointment.ChosenAppointmentTime == null)
            {
                time = appointment.DateTimeModel.Times.ToList()[0].Text;
            }
            else
            {
                time = appointment.ChosenAppointmentTime;
            }

            //Concatenate chosen appointment date & time together
            string finalDate = $"{appointment.AppointmentModel.AppointmentDate} - {time}";
            _ = ModelState.IsValid;
            try
            {
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
                        VM.DateTimeModel.FindTimesAndRemove(ListOfAppointmentDates, SelectedDate);
                        ViewBag.Saved = "Saved";
                        //return RedirectToAction("Home", "Home");
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            //return RedirectToAction("Index", "Appointment");
            return View("Index");
        }
    }
}