using InnoClinic.AppointmentsAPI.Core.Entitites.Models;
using InnoClinic.AppointmentsAPI.Core.Enums;

namespace InnoClinic.AppointmentsAPI.Core.Contracts.Repositories
{
    public interface IAppointmentRepository
    {
        Task<IEnumerable<Appointment>> GetAllAppointmentsAsync(bool trackChanges = false);
        Task<Appointment> GetAppointmentAsync(Guid appointmentId, bool trackChanges = false);
        Task CreateAppointmentAsync(Appointment appointment);
        Task DeleteAppointmentAsync(Appointment appointment);
        Task UpdateAppointmentsByStatusAndServiceId(StatusEnum status, Guid serviceId, string serviceName);
        Task SaveAsync();
    }
}
