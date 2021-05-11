using System;
using WebshopBouidi.DAL.Appointment;
using WebshopBouidi.Models;

namespace WebshopBouidi.BAL.Appointment
{
    public static class AppointmentBAL
    {
        private static AppointmentDAL AppointmentDAL { get; } = new AppointmentDAL();
        private static DateTime Today { get; } = new DateTime();
        public static void CreateAppointment(AppointmentModel appointment)
        {
            if (appointment.AppointmentDate.Value.Date > Today.Date && appointment.CustomerName.Length > 0 && appointment.CustomerLastName.Length > 0 && appointment.Email.Length > 0 && appointment.MobileNumber.Length > 0)
            {
                AppointmentModel modelToCreate = new AppointmentModel
                {
                    CustomerName = appointment.CustomerName,
                    CustomerLastName = appointment.CustomerLastName,
                    Email = appointment.Email,
                    MobileNumber = appointment.MobileNumber,
                    Message = appointment.Message
                };
                AppointmentDAL.Create(modelToCreate);
            }
        }
    }
}