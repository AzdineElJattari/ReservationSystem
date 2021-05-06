namespace WebshopBouidi.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using WebshopBouidi.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.ProjectContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.ProjectContext context)
        {
            var appointments = new List<AppointmentModel>
            {
                new AppointmentModel { CustomerName = "Azdine",   CustomerLastName = "El Jattari",
                    Email = "Azdine.eljattari@hotmail.com", MobileNumber= "0465072972" },
                new AppointmentModel { CustomerName = "Carson",   CustomerLastName = "Alexander",
                    Email = "Carson.Alexander@hotmail.com", MobileNumber= "0485778899" }
            };
            appointments.ForEach(s => context.Appointments.AddOrUpdate(p => p.Id, s));
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }
    }
}
