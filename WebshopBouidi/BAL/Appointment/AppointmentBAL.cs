using System;
using WebshopBouidi.DAL.Appointment;
using WebshopBouidi.Models;

namespace WebshopBouidi.BAL.Appointment
{
    public static class AppointmentBAL
    {
        private static AppointmentDAL AppointmentDAL { get; } = new AppointmentDAL();
        public static void CreateAppointment(AppointmentModel appointment)
        {
            try
            {
                AppointmentModel modelToCreate = new AppointmentModel
                {
                    CustomerName = appointment.CustomerName,
                    CustomerLastName = appointment.CustomerLastName,
                    Email = appointment.Email,
                    MobileNumber = appointment.MobileNumber,
                    AppointmentDate = appointment.AppointmentDate,
                    Message = appointment.Message
                };
                AppointmentDAL.Create(modelToCreate);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}