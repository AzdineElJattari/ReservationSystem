using System.Linq;
using WebshopBouidi.Models;

namespace WebshopBouidi.DAL.Appointment
{
    public class AppointmentDAL
    {
        private ProjectContext context { get; } = new ProjectContext();

        public void Create(AppointmentModel appointment)
        {
            context.Appointments.Add(appointment);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var appointmentToDelete = context.Appointments.SingleOrDefault(x => x.Id == id);
            context.Appointments.Remove(appointmentToDelete);
            context.SaveChanges();
        }
    }
}