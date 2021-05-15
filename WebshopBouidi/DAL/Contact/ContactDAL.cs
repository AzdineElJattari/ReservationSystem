using System;
using System.Linq;
using WebshopBouidi.Models;

namespace WebshopBouidi.DAL.Contact
{
    public class ContactDAL
    {
        private ProjectContext context { get; } = new ProjectContext();

        public void Create(ContactModel contact)
        {
            context.Contacts.Add(contact);
            context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var contactToDelete = context.Contacts.SingleOrDefault(x => x.Id == id);
            context.Contacts.Remove(contactToDelete);
            context.SaveChanges();
        }
    }
}