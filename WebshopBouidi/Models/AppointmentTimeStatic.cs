using System.Collections.Generic;

namespace WebshopBouidi.Models
{
    public static class AppointmentTimeStatic
    {

        private static List<System.Web.Mvc.SelectListItem> times = new List<System.Web.Mvc.SelectListItem>
        {
            new System.Web.Mvc.SelectListItem() { Value =  "11:00", Text = "11:00", Disabled = false },
            new System.Web.Mvc.SelectListItem() { Value =  "11:30", Text = "11:30", Disabled = false },
            new System.Web.Mvc.SelectListItem() { Value =  "12:00", Text = "12:00", Disabled = false },
            new System.Web.Mvc.SelectListItem() { Value =  "12:30", Text = "12:30", Disabled = false },
            new System.Web.Mvc.SelectListItem() { Value =  "13:00", Text = "13:00", Disabled = false },
            new System.Web.Mvc.SelectListItem() { Value =  "13:30", Text = "13:30", Disabled = false },
            new System.Web.Mvc.SelectListItem() { Value =  "14:00", Text = "14:00", Disabled = false },
            new System.Web.Mvc.SelectListItem() { Value =  "14:30", Text = "14:30", Disabled = false },
            new System.Web.Mvc.SelectListItem() { Value =  "15:00", Text = "15:00", Disabled = false },
            new System.Web.Mvc.SelectListItem() { Value =  "15:30", Text = "15:30", Disabled = false },
            new System.Web.Mvc.SelectListItem() { Value =  "16:00", Text = "16:00", Disabled = false },
            new System.Web.Mvc.SelectListItem() { Value =  "16:30", Text = "16:30", Disabled = false },
            new System.Web.Mvc.SelectListItem() { Value =  "17:00", Text = "17:00", Disabled = false },
            new System.Web.Mvc.SelectListItem() { Value =  "17:30", Text = "17:30", Disabled = false },
            new System.Web.Mvc.SelectListItem() { Value =  "18:00", Text = "18:00", Disabled = false }
        };
        public static IEnumerable<System.Web.Mvc.SelectListItem> Times
        {
            get
            {
                return times;
            }
        }

        public static void DisableTime(string timeToDisable)
        {
            times.RemoveAll(x => x.Text == timeToDisable);
        }

        public static void ResetTimeList()
        {
            times = new List<System.Web.Mvc.SelectListItem>
            {
                new System.Web.Mvc.SelectListItem() { Value =  "11:00", Text = "11:00", Disabled = false },
                new System.Web.Mvc.SelectListItem() { Value =  "11:30", Text = "11:30", Disabled = false },
                new System.Web.Mvc.SelectListItem() { Value =  "12:00", Text = "12:00", Disabled = false },
                new System.Web.Mvc.SelectListItem() { Value =  "12:30", Text = "12:30", Disabled = false },
                new System.Web.Mvc.SelectListItem() { Value =  "13:00", Text = "13:00", Disabled = false },
                new System.Web.Mvc.SelectListItem() { Value =  "13:30", Text = "13:30", Disabled = false },
                new System.Web.Mvc.SelectListItem() { Value =  "14:00", Text = "14:00", Disabled = false },
                new System.Web.Mvc.SelectListItem() { Value =  "14:30", Text = "14:30", Disabled = false },
                new System.Web.Mvc.SelectListItem() { Value =  "15:00", Text = "15:00", Disabled = false },
                new System.Web.Mvc.SelectListItem() { Value =  "15:30", Text = "15:30", Disabled = false },
                new System.Web.Mvc.SelectListItem() { Value =  "16:00", Text = "16:00", Disabled = false },
                new System.Web.Mvc.SelectListItem() { Value =  "16:30", Text = "16:30", Disabled = false },
                new System.Web.Mvc.SelectListItem() { Value =  "17:00", Text = "17:00", Disabled = false },
                new System.Web.Mvc.SelectListItem() { Value =  "17:30", Text = "17:30", Disabled = false },
                new System.Web.Mvc.SelectListItem() { Value =  "18:00", Text = "18:00", Disabled = false }
            };
        }
    }
}