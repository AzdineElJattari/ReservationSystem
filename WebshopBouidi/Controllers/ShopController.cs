using System.Web.Mvc;

namespace WebshopBouidi.Controllers
{
    public class ShopController : Controller
    {
        public ActionResult Index() //Naam moet overeenkomen met de naam van de view
        {
            return View();
        }
    }
}