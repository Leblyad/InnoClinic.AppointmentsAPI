namespace InnoClinic.AppointmentsAPI.Core.Exceptions.UserExceptions
{
    public class AppointmentNotFoundException : NotFoundException
    {
        public AppointmentNotFoundException(Guid appointmentId)
            : base($"The appointment with the identifier {appointmentId} was not found.")
        {
        }
    }
}
