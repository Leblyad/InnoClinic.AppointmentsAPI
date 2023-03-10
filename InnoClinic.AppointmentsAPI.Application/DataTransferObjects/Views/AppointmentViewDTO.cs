using InnoClinic.AppointmentsAPI.Application.ExternalModels;
using InnoClinic.AppointmentsAPI.Core.Enums;

namespace InnoClinic.AppointmentsAPI.Application.DataTransferObjects.Views
{
    public class AppointmentViewDTO
    {
        public Guid Id { get; set; }
        public string OfficeId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public Duration Duration { get; set; }
        public StatusEnum Status { get; set; }
        public string ServiceName { get; set; }
        public Guid ServiceId { get; set; }

        public DoctorDTO Doctor { get; set; }
        public PatientDTO Patient { get; set; }
    }
}
