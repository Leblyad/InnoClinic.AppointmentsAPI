using InnoClinic.AppointmentsAPI.Core.Contracts.Repositories;
using InnoClinic.AppointmentsAPI.Core.Entitites.Models;
using InnoClinic.AppointmentsAPI.Core.Entitites.QueryParameters;
using InnoClinic.AppointmentsAPI.Core.Enums;
using Microsoft.EntityFrameworkCore;

namespace InnoClinic.AppointmentsAPI.Infrastructure.Repository.UserClasses
{
    public class AppointmentRepository : RepositoryBase<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task CreateAppointmentAsync(Appointment appointment)
        {
            Create(appointment);
            await RepositoryContext.SaveChangesAsync();
        }

        public async Task DeleteAppointmentAsync(Appointment appointment)
        {
            Delete(appointment);
            await RepositoryContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAllAppointmentsByPagesAsync(AppointmentQueryParameters appointmentParameters, bool trackChanges = false) =>
            appointmentParameters.PageNumber > 0
            && appointmentParameters.PageSize > 0 ?
            await FindAll(trackChanges)
                .Skip((appointmentParameters.PageNumber - 1) * appointmentParameters.PageSize)
                .Take(appointmentParameters.PageSize)
                .OrderBy(app => app.Time)
            .ThenBy(app => app.Date)
                        .ThenBy(app => app.Date)
                .ToListAsync() :
            await FindAll(trackChanges)
                .ToListAsync();

        public async Task<Appointment> GetAppointmentAsync(Guid appointmentId, bool trackChanges = false) =>
            await FindByCondition(appointment => appointment.Id.Equals(appointmentId), trackChanges)
                .SingleOrDefaultAsync();

        public Task SaveAsync() => RepositoryContext.SaveChangesAsync();

        public async Task UpdateAppointmentsByStatusAndServiceIdAsync(StatusEnum status, Guid serviceId, string serviceName)
        {
            var appointments = await FindByCondition(app => app.ServiceId.Equals(serviceId), trackChanges: true)
                .Where(app => app.Status.Equals(status)).ToListAsync();
            foreach (var app in appointments)
            {
                app.ServiceName = serviceName;
            }
            await SaveAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAllAppointmentsAsync(bool trackChanges = false) =>
            await FindAll(trackChanges)
                .ToListAsync();

        public async Task<IEnumerable<Appointment>> GetAppointmentsByPatientIdAsync(Guid patientId, bool trackChanges = false) =>
            await FindByCondition(app => app.PatientId.Equals(patientId), trackChanges)
            .ToListAsync();

        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctorIdAsync(Guid doctorId, bool trackChanges = false) =>
            await FindByCondition(app => app.DoctorId.Equals(doctorId), trackChanges)
            .ToListAsync();

        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctorForWeekAsync(Guid doctorId, bool trackChanges = false) =>
            await FindByCondition(app => app.DoctorId.Equals(doctorId) && (app.Date.Date >= DateTime.Now.Date && app.Date.Date <= DateTime.Now.AddDays(7).Date), trackChanges)
            .ToListAsync();
    }
}

