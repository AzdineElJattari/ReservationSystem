using System.ComponentModel.DataAnnotations;

namespace WebshopBouidi.Models
{
    public class AppointmentModel
    {
        [Required(ErrorMessage = "Please enter name"), MaxLength(30)]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Please enter last name"), MaxLength(30)]
        public string CustomerLastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid")]
        public string Email { get; set; }

        [RegularExpression(@"^([0]|\+91[\-\s]?)?[789]\d{9}$", ErrorMessage = "Mobile No. is not valid")]
        public string MobileNumber { get; set; }
    }
}