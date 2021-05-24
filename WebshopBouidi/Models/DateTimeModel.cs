using System.Collections.Generic;

namespace WebshopBouidi.Models
{
    public class DateTimeModel
    {
        List<SelectType> openingTimes = new List<SelectType>
        {
            new SelectType() { Value =  "11:00", Text = "11:00" },
            new SelectType() { Value =  "11:30", Text = "11:30" },
            new SelectType() { Value =  "12:00", Text = "12:00" },
            new SelectType() { Value =  "12:30", Text = "12:30" },
            new SelectType() { Value =  "13:00", Text = "13:00" },
            new SelectType() { Value =  "13:30", Text = "13:30" },
            new SelectType() { Value =  "14:00", Text = "14:00" },
            new SelectType() { Value =  "14:30", Text = "14:30" },
            new SelectType() { Value =  "15:00", Text = "15:00" },
            new SelectType() { Value =  "15:30", Text = "15:30" },
            new SelectType() { Value =  "16:00", Text = "16:00" },
            new SelectType() { Value =  "16:30", Text = "16:30" },
            new SelectType() { Value =  "17:00", Text = "17:00" },
            new SelectType() { Value =  "17:30", Text = "17:30" },
            new SelectType() { Value =  "18:00", Text = "18:00" }
    };

        public List<SelectType> OpeningTimes { get { return openingTimes; } }
    }
}