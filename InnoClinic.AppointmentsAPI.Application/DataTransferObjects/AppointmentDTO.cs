namespace InnoClinic.AppointmentsAPI.Application.DataTransferObjects
{
    public class AppointmentDTO
    {
        public Guid Id { get; set; }
        public Guid SpecializationId { get; set; }
        public Guid DoctorId { get; set; }
        public Guid ServiceId { get; set; }
        public Guid OfficeId { get; set; }
        public string Date { get; set; }
        public string Timeslots { get; set; }
        public string Status { get; set; }
        public string ServiceName { get; set; }
    }
}
