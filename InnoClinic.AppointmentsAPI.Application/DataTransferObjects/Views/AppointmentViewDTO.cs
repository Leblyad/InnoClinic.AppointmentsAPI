using InnoClinic.AppointmentsAPI.Application.ExternalModels;
using InnoClinic.AppointmentsAPI.Core.Enums;

namespace InnoClinic.AppointmentsAPI.Application.DataTransferObjects.Views
{
    public class AppointmentViewDTO
    {
        public Guid Id { get; set; }
        public Guid OfficeId { get; set; }
        public string Date { get; set; }
        public string Timeslots { get; set; }
        public StatusEnum Status { get; set; }
        public string ServiceName { get; set; }

        public DoctorDTO Doctor { get; set; }
        public PatientDTO Patient { get; set; }
    }
}
