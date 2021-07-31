namespace WebshopBouidi.Models
{
    public class ViewModel
    {

        public AppointmentModel AppointmentModel { get; } = new AppointmentModel();
        public DateTimeModel DateTimeModel { get; } = new DateTimeModel();
        public string ChosenAppointmentTime { get; set; }
    }
}