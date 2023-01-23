namespace InnoClinic.AppointmentsAPI.Application.ExternalModels
{
    public class PatientDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
    }
}
