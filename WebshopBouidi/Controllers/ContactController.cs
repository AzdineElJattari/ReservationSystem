using System.Web.Mvc;

namespace WebshopBouidi.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index() //Naam moet overeenkomen met de naam van de view
        {
            {
                return View();
            }
        }
    }
}