using System;
using WebshopBouidi.DAL.Contact;
using WebshopBouidi.Models;

namespace WebshopBouidi.BAL.Contact
{
    public class ContactBAL
    {
        private static ContactDAL ContactDAL { get; } = new ContactDAL();
        public static void CreateContact(ContactModel contact)
        {
            try
            {
                ContactModel modelToCreate = new ContactModel
                {
                    Name = contact.Name,
                    LastName = contact.LastName,
                    Email = contact.Email,
                    Message = contact.Message,
                    CreationDate = DateTime.Now.ToString("g")
                };
                ContactDAL.Create(modelToCreate);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

    }
}