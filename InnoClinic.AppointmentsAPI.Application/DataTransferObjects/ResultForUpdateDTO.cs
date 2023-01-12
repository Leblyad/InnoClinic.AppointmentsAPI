using System.ComponentModel.DataAnnotations;

namespace InnoClinic.AppointmentsAPI.Application.DataTransferObjects
{
    public class ResultForUpdateDTO
    {
        [Required]
        public string Complaints { get; set; }
        [Required]
        public string Conclusion { get; set; }
        [Required]
        public string Recommendations { get; set; }
    }
}
