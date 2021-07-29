using System.Collections.Generic;

namespace WebshopBouidi.Models
{
    public class DateTimeModel
    {
        public IEnumerable<System.Web.Mvc.SelectListItem> OpeningTimes { get { return AppointmentTimeStatic.Times; } }
    }
}