namespace InnoClinic.AppointmentsAPI.Core.Exceptions
{
    public class CustomNullReferenceException : NullReferenceException
    {
        public CustomNullReferenceException(Type type)
            : base($"Object of type: {type.Name} is null.")
        { }
    }
}
