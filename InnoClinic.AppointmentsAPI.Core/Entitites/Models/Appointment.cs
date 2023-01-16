using InnoClinic.AppointmentsAPI.Core.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InnoClinic.AppointmentsAPI.Core.Entitites.Models
{
    public class Appointment
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public Guid SpecializationId { get; set; }
        [Required]
        public Guid DoctorId { get; set; }
        [Required]
        public Guid ServiceId { get; set; }
        [Required]
        public Guid OfficeId { get; set; }
        [Required]
        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public string Timeslots { get; set; }
        [Required]
        public StatusEnum Status { get; set; }
        public string ServiceName { get; set; }
    }
}
