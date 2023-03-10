using InnoClinic.AppointmentsAPI.Core.Enums;

namespace InnoClinic.AppointmentsAPI.Application.DataTransferObjects
{
    public class AppointmentDTO
    {
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
        public Guid DoctorId { get; set; }
        public Guid ServiceId { get; set; }
        public string OfficeId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public Duration Duration { get; set; }
        public StatusEnum Status { get; set; }
        public string ServiceName { get; set; }
    }
}
