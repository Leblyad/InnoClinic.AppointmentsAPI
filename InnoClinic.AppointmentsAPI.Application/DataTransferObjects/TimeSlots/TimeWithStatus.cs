namespace InnoClinic.AppointmentsAPI.Application.DataTransferObjects.TimeSlots
{
    public class TimeWithStatus
    {
        public TimeSpan Time { get; set; }
        public bool IsFree { get; set; } = true;
    }
}
