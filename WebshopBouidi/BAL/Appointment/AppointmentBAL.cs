using System;
using WebshopBouidi.DAL.Appointment;
using WebshopBouidi.Models;

namespace WebshopBouidi.BAL.Appointment
{
    public class AppointmentBAL
    {
        private AppointmentDAL AppointmentDAL { get; }
        private DateTime Today { get; }
        public void CreateAppointment(AppointmentModel appointment)
        {
            if (appointment.AppointmentDate.Date > Today.Date && appointment.CustomerName.Length > 0 && appointment.CustomerLastName.Length > 0 && appointment.Email.Length > 0 && appointment.MobileNumber.Length > 0)
            {
                AppointmentDAL.Create(appointment);
            } // NOG NIET AF
        }
    }
}