using InnoClinic.AppointmentsAPI.Application.DataTransferObjects;
using InnoClinic.AppointmentsAPI.Application.DataTransferObjects.Views;
using InnoClinic.AppointmentsAPI.Core.Entitites.QueryParameters;

namespace InnoClinic.AppointmentsAPI.Application.Services.Abstractions
{
    public interface IAppointmentService
    {
        Task<IEnumerable<AppointmentDTO>> GetAllAppointmentsByPagesAsync(AppointmentQueryParameters appointmentParameters);
        Task<IEnumerable<AppointmentViewDTO>> GetAllAppointmentsAsync(string accessToken);
        Task<AppointmentDTO> GetAppointmentAsync(Guid appointmentId);
        Task<AppointmentDTO> CreateAppointmentAsync(AppointmentForCreationDTO appointment);
        Task UpdateAppointmentAsync(Guid appointmentId, AppointmentForUpdateDTO appointment);
        Task DeleteAppointmentAsync(Guid appointmentId);
    }
}
