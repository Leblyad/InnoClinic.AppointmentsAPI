using InnoClinic.AppointmentsAPI.Application.DataTransferObjects;
using InnoClinic.AppointmentsAPI.Application.DataTransferObjects.TimeSlots;
using InnoClinic.AppointmentsAPI.Application.DataTransferObjects.Views;
using InnoClinic.AppointmentsAPI.Core.Entitites.QueryParameters;

namespace InnoClinic.AppointmentsAPI.Application.Services.Abstractions
{
    public interface IAppointmentService
    {
        Task<IEnumerable<AppointmentDTO>> GetAllAppointmentsByPagesAsync(AppointmentQueryParameters appointmentParameters);
        Task<IEnumerable<AppointmentViewDTO>> ViewAppointmentListByReceptionistAsync(string accessToken);
        Task<IEnumerable<AppointmentViewDTO>> ViewAppointmentHistoryByDoctorAndPatientAsync(Guid patientId, string accessToken);
        Task<IEnumerable<AppointmentViewDTO>> ViewAppointmentScheduleByDoctorAsync(Guid doctorId, string accessToken);
        Task<AppointmentDTO> GetAppointmentAsync(Guid appointmentId);
        Task<AppointmentDTO> CreateAppointmentAsync(AppointmentForCreationDTO appointment);
        Task UpdateAppointmentAsync(Guid appointmentId, AppointmentForUpdateDTO appointment);
        Task<IEnumerable<DateWithTimeSlots>> GetTimeSlotsAsync(Guid doctorId);
    }
}
