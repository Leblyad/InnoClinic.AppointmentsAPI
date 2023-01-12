namespace InnoClinic.AppointmentsAPI.Core.Exceptions.UserExceptions
{
    public class ResultNotFoundException : NotFoundException
    {
        public ResultNotFoundException(Guid resultId)
            : base($"The resultId with the identifier {resultId} was not found.")
        {
        }
    }
}
