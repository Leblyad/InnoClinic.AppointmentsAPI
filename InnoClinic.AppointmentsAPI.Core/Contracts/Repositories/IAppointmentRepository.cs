
using InnoClinic.AppointmentsAPI.Core.Entitites.Models;
using InnoClinic.AppointmentsAPI.Core.Entitites.QueryParameters;
using InnoClinic.AppointmentsAPI.Core.Enums;

namespace InnoClinic.AppointmentsAPI.Core.Contracts.Repositories
{
    public interface IAppointmentRepository
    {
        Task<IEnumerable<Appointment>> GetAllAppointmentsByPagesAsync(AppointmentQueryParameters appointmentParameters, bool trackChanges = false);
        Task<IEnumerable<Appointment>> GetAllAppointmentsAsync(bool trackChanges = false);
        Task<Appointment> GetAppointmentAsync(Guid appointmentId, bool trackChanges = false);
        Task CreateAppointmentAsync(Appointment appointment);
        Task DeleteAppointmentAsync(Appointment appointment);
        Task UpdateAppointmentsByStatusAndServiceIdAsync(StatusEnum status, Guid serviceId, string serviceName);
        Task<IEnumerable<Appointment>> GetAppointmentsByPatientIdAsync(Guid patientId, bool trackChanges = false);
        Task<IEnumerable<Appointment>> GetAppointmentsByDoctorIdAsync(Guid doctorId, bool trackChanges = false);
        Task<IEnumerable<Appointment>> GetAppointmentsByDoctorForWeekAsync(Guid doctorId, bool trackChanges = false);
        Task SaveAsync();
    }
}
