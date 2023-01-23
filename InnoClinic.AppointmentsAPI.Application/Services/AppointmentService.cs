using AutoMapper;
using InnoClinic.AppointmentsAPI.Application.DataTransferObjects;
using InnoClinic.AppointmentsAPI.Application.DataTransferObjects.Views;
using InnoClinic.AppointmentsAPI.Application.ExternalModels;
using InnoClinic.AppointmentsAPI.Application.Services.Abstractions;
using InnoClinic.AppointmentsAPI.Application.Wrappers;
using InnoClinic.AppointmentsAPI.Core.Contracts.Repositories;
using InnoClinic.AppointmentsAPI.Core.Entitites.Models;
using InnoClinic.AppointmentsAPI.Core.Entitites.QueryParameters;
using InnoClinic.AppointmentsAPI.Core.Exceptions;
using InnoClinic.AppointmentsAPI.Core.Exceptions.UserExceptions;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace InnoClinicAPI.AppointmentsAPI.Application.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public AppointmentService(IAppointmentRepository appointmentRepository, IMapper mapper, IConfiguration configuration)
        {
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<AppointmentDTO> CreateAppointmentAsync(AppointmentForCreationDTO appointment)
        {
            if (appointment == null)
            {
                throw new CustomNullReferenceException(typeof(AppointmentForCreationDTO));
            }

            var appointmentEntity = _mapper.Map<Appointment>(appointment);
            await _appointmentRepository.CreateAppointmentAsync(appointmentEntity);

            return _mapper.Map<AppointmentDTO>(appointmentEntity);
        }

        public async Task DeleteAppointmentAsync(Guid appointmentId)
        {
            var appointment = await _appointmentRepository.GetAppointmentAsync(appointmentId);

            if (appointment == null)
            {
                throw new AppointmentNotFoundException(appointmentId);
            }

            await _appointmentRepository.DeleteAppointmentAsync(appointment);
        }

        public async Task<IEnumerable<AppointmentDTO>> GetAllAppointmentsByPagesAsync(AppointmentQueryParameters appointmentParameters)
        {
            var appointmentsCollection = await _appointmentRepository.GetAllAppointmentsByPagesAsync(appointmentParameters);

            return _mapper.Map<IEnumerable<AppointmentDTO>>(appointmentsCollection);
        }

        public async Task<AppointmentDTO> GetAppointmentAsync(Guid appointmentId)
        {
            var appointment = await _appointmentRepository.GetAppointmentAsync(appointmentId);

            if (appointment == null)
            {
                throw new AppointmentNotFoundException(appointmentId);
            }

            return _mapper.Map<AppointmentDTO>(appointment);
        }

        public async Task UpdateAppointmentAsync(Guid appointmentId, AppointmentForUpdateDTO appointment)
        {
            if (appointment == null)
            {
                throw new CustomNullReferenceException(typeof(AppointmentForUpdateDTO));
            }

            var appointmentEntity = await _appointmentRepository.GetAppointmentAsync(appointmentId, trackChanges: true);

            if (appointmentEntity == null)
            {
                throw new AppointmentNotFoundException(appointmentId);
            }

            _mapper.Map(appointment, appointmentEntity);

            await _appointmentRepository.SaveAsync();
        }

        public async Task<IEnumerable<AppointmentViewDTO>> GetAllAppointmentsAsync(string accessToken)
        {
            var appointments = await _appointmentRepository.GetAllAppointmentsAsync();

            var doctorsIds = appointments.Select(doc => doc.DoctorId).Distinct();
            var patientIds = appointments.Select(pat => pat.PatientId).Distinct();
            var servicesIds = appointments.Select(serv => serv.ServiceId).Distinct();

            var httpClient = new HttpClientWrapper(accessToken, _configuration);

            var doctors = await httpClient.GetEntities<DoctorDTO>(doctorsIds);
            var patients = await httpClient.GetEntities<PatientDTO>(patientIds);
            var services = await httpClient.GetEntities<ServiceDTO>(servicesIds);

            var appointmentsView = _mapper.Map<IEnumerable<AppointmentViewDTO>>(appointments);

            foreach(var app in appointmentsView)
            {
                app.Doctor = doctors.FirstOrDefault(doc => app.Doctor.Id.Equals(doc.Id));
                app.Patient = patients.FirstOrDefault(pat => app.Patient.Id.Equals(pat.Id));
                app.Patient = patients.FirstOrDefault(serv => app.Service.Id.Equals(serv.Id));
            }

            return appointmentsView;
        }
    }
}
