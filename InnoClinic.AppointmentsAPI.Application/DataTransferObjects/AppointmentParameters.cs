namespace InnoClinic.AppointmentsAPI.Application.DataTransferObjects
{
    public class AppointmentParameters
    {
        public Guid DoctorId { get; set; }
        public DateTime Date { get; set; }
    }
}
