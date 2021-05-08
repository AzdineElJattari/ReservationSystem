namespace WebshopBouidi.Models
{
    public class ParentViewModel
    {
        public AppointmentModel AppointmentModel { get; set; }
        public DateTimeModel DateTimeModel { get; set; }

        public ParentViewModel()
        {
            AppointmentModel = new AppointmentModel();
            DateTimeModel = new DateTimeModel();
        }
    }
}