using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebshopBouidi.BAL.Contact;
using WebshopBouidi.Models;

namespace WebshopBouidi.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            {
                return View();
            }
        }

        //POST: Appointment
        [HttpPost]
        public async Task<ActionResult> Create(ContactModel contact)
        {
            if (ModelState.IsValid)
            {
                var body = $"<p></p>"; //AANPASSEN
                var message = new MailMessage();
                message.To.Add(new MailAddress(contact.Email)); //VERANDEREN
                message.From = new MailAddress("testmail.bouidi@gmail.com"); //VERANDEREN
                message.Subject = $""; //AANPASSEN
                message.Body = string.Format(body);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(System.Configuration.ConfigurationManager.AppSettings["FromEmail"], System.Configuration.ConfigurationManager.AppSettings["FromPassword"]);
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);
                    ContactBAL.CreateContact(contact);
                    ViewBag.Msg = ""; //AANPASSEN
                    return RedirectToAction("Index", "Contact");
                }
            }
            return PartialView("Index", contact);
        }

    }
}