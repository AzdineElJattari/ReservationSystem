using Microsoft.AspNetCore.Mvc;
using System;

namespace WebshopBouidi.Models
{
    public class DateTimeBinder
    {

        [BindProperty]
        public DateTime DateTime { get; set; }
    }
}