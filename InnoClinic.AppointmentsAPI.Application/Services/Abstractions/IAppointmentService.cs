using InnoClinic.AppointmentsAPI.Application.DataTransferObjects;

namespace InnoClinic.AppointmentsAPI.Application.Services.Abstractions
{
    public interface IAppointmentService
    {
        Task<IEnumerable<AppointmentDTO>> GetAllAppointmentsAsync();
        Task<AppointmentDTO> GetAppointmentAsync(Guid appointmentId);
        Task<AppointmentDTO> CreateAppointmentAsync(AppointmentForCreationDTO appointment);
        Task UpdateAppointmentAsync(Guid appointmentId, AppointmentForUpdateDTO appointment);
        Task DeleteAppointmentAsync(Guid appointmentId);
    }
}
