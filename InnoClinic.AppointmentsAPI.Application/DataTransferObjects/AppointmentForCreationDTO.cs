using InnoClinic.AppointmentsAPI.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace InnoClinic.AppointmentsAPI.Application.DataTransferObjects
{
    public class AppointmentForCreationDTO
    {
        [Required]
        public Guid DoctorId { get; set; }
        [Required]
        public Guid PatientId { get; set; }
        [Required]
        public Guid ServiceId { get; set; }
        [Required]
        public Guid OfficeId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public string Timeslots { get; set; }
        [Required]
        public StatusEnum Status { get; set; }
        public string ServiceName { get; set; }
    }
}
