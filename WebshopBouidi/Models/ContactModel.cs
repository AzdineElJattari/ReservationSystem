using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebshopBouidi.Models
{
    [Table("Contact")]
    public class ContactModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; private set; }

        [Required(ErrorMessage = "Naam is verplicht"), MaxLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Achternaam is verplicht"), MaxLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "E-mail is verplicht")]
        [EmailAddress(ErrorMessage = "E-mail adres is niet geldig")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Bericht ingeven is verplicht"), MaxLength]
        public string Message { get; set; }
    }
}