using System.ComponentModel.DataAnnotations;

namespace InnoClinic.AppointmentsAPI.Core.Entitites.Models
{
    public class Result
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Complaints { get; set; }
        [Required]
        public string Conclusion { get; set; }
        [Required]
        public string Recommendations { get; set; }
    }
}
