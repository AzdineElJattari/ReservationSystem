﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebshopBouidi.Models
{
    public class AppointmentModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

        [Required(ErrorMessage = "Naam is verplicht"), MaxLength(50)]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Achternaam is verplicht"), MaxLength(50)]
        public string CustomerLastName { get; set; }

        [Required(ErrorMessage = "E-mail is verplicht")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is niet geldig")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mobiele nr. is verplicht")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Mobiele nr. is niet geldig")]
        public string MobileNumber { get; set; }

        [Required(ErrorMessage = "Datum afspraak is verplicht")]
        public DateTime? AppointmentDate { get; set; } // DATE WERKT NIET -> WORDT OPGESLAGEN AlS NULL IN DB

        [MaxLength]
        public string Message { get; set; }
    }
}