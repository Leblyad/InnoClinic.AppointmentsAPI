using InnoClinic.AppointmentsAPI.Core.Entitites.Models;

namespace InnoClinic.AppointmentsAPI.Core.Contracts.Repositories
{
    public interface IAppointmentRepository
    {
        Task<IEnumerable<Appointment>> GetAllAppointmentsAsync(bool trackChanges = false);
        Task<Appointment> GetAppointmentAsync(Guid appointmentId, bool trackChanges = false);
        Task CreateAppointmentAsync(Appointment appointment);
        Task DeleteAppointmentAsync(Appointment appointment);
        Task<IEnumerable<Appointment>> SearchAppointmentsByField(string status, bool trackChanges = false);
        Task SaveAsync();
    }
}
