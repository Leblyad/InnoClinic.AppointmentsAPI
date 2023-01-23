namespace InnoClinic.AppointmentsAPI.Application.ExternalModels
{
    public class DoctorDTO
    {
        public Guid Id { get; set; }
        public Guid PhotoId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string CareerStartYear { get; set; }
    }
}
