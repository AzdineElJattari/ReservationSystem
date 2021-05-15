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

        //POST: Contact
        [HttpPost]
        public async Task<ActionResult> Create(ContactModel contact)
        {
            if (ModelState.IsValid)
            {
                var body = $"<p>{contact.Message}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("testmail.bouidi@gmail.com"));
                message.From = new MailAddress(contact.Email);
                message.Subject = $"Contact bericht van {contact.Name} {contact.LastName} opgemaakt op {contact.CreationDate}"; //AANPASSEN
                message.Body = string.Format(body);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(System.Configuration.ConfigurationManager.AppSettings["FromEmail"], System.Configuration.ConfigurationManager.AppSettings["FromPassword"]);
                    smtp.EnableSsl = true;
                    _ = message;
                    await smtp.SendMailAsync(message);
                    ContactBAL.CreateContact(contact);
                    ViewBag.Msg = "Dankjewel voor het opmaken en verzenden van uw contact bericht, we nemen snel contact met u op!"; //AANPASSEN
                    return RedirectToAction("Index", "Contact");
                }
            }
            return PartialView("Index", contact);
        }
    }
}