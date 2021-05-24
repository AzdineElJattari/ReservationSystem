using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebshopBouidi.Models
{
    [Table("Appointment")]
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
        [EmailAddress(ErrorMessage = "E-mail adres is niet geldig")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mobiele nr. is verplicht")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Mobiele nr. is niet geldig")]
        public string MobileNumber { get; set; }

        [Required(ErrorMessage = "Datum afspraak is verplicht")]
        public string AppointmentDate { get; set; } //Changed from DateTime to String

        [MaxLength]
        public string Message { get; set; }
    }
}