namespace WebshopBouidi.Models
{
    public class ViewModel
    {
        public AppointmentModel AppointmentModel { get; set; } = new AppointmentModel();
        public DateTimeModel DateTimeModel { get; set; } = new DateTimeModel();
        public string ChosenAppointmentTime { get; set; }
    }
}