﻿using InnoClinic.AppointmentsAPI.Core.Contracts.Repositories;
using InnoClinic.AppointmentsAPI.Core.Entitites.Models;
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

        public async Task<IEnumerable<Appointment>> GetAllAppointmentsAsync(bool trackChanges = false) =>
            await FindAll(trackChanges)
            .ToListAsync();

        public async Task<Appointment> GetAppointmentAsync(Guid appointmentId, bool trackChanges = false) =>
            await FindByCondition(appointment => appointment.Id.Equals(appointmentId), trackChanges)
                .SingleOrDefaultAsync();

        public Task SaveAsync() => RepositoryContext.SaveChangesAsync();

        public async Task UpdateAppointmentsByStatusAndServiceId(StatusEnum status, Guid serviceId, string serviceName)
        {
            var appointments = await FindByCondition(app => app.ServiceId.Equals(serviceId), trackChanges: true)
                .Where(app => app.Status.Equals(status)).ToListAsync();
            foreach (var app in appointments)
            {
                app.ServiceName = serviceName;
            }
            await SaveAsync();
        }
    }
}

