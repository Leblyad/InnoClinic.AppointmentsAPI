﻿using AutoMapper;
using InnoClinic.AppointmentsAPI.Application.DataTransferObjects;
using InnoClinic.AppointmentsAPI.Application.DataTransferObjects.TimeSlots;
using InnoClinic.AppointmentsAPI.Application.DataTransferObjects.Views;
using InnoClinic.AppointmentsAPI.Application.ExternalModels;
using InnoClinic.AppointmentsAPI.Application.Services;
using InnoClinic.AppointmentsAPI.Application.Services.Abstractions;
using InnoClinic.AppointmentsAPI.Application.Wrappers;
using InnoClinic.AppointmentsAPI.Core.Contracts.Repositories;
using InnoClinic.AppointmentsAPI.Core.Entitites.Models;
using InnoClinic.AppointmentsAPI.Core.Entitites.QueryParameters;
using InnoClinic.AppointmentsAPI.Core.Exceptions;
using InnoClinic.AppointmentsAPI.Core.Exceptions.UserExceptions;
using Microsoft.Extensions.Configuration;

namespace InnoClinicAPI.AppointmentsAPI.Application.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public AppointmentService(IAppointmentRepository appointmentRepository, IMapper mapper, IConfiguration configuration, HttpClient httpClient)
        {
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
            _configuration = configuration;
            _httpClient = httpClient;
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

        public async Task<IEnumerable<AppointmentViewDTO>> ViewAppointmentListByReceptionistAsync(string accessToken)
        {
            var appointments = await _appointmentRepository.GetAllAppointmentsAsync();

            var doctorsIds = appointments.Select(doc => doc.DoctorId).Distinct();
            var patientIds = appointments.Select(pat => pat.PatientId).Distinct();

            var httpClient = new HttpClientWrapper(_httpClient, accessToken, _configuration);

            var doctors = await httpClient.GetEntities<DoctorDTO>(doctorsIds);
            var patients = await httpClient.GetEntities<PatientDTO>(patientIds);

            var appointmentsView = _mapper.Map<IEnumerable<AppointmentViewDTO>>(appointments);

            foreach (var app in appointmentsView)
            {
                app.Doctor = doctors.FirstOrDefault(doc => app.Doctor.Id.Equals(doc.Id));
                app.Patient = patients.FirstOrDefault(pat => app.Patient.Id.Equals(pat.Id));
            }

            return appointmentsView;
        }

        public async Task<IEnumerable<AppointmentViewDTO>> ViewAppointmentHistoryByDoctorAndPatientAsync(Guid patientId, string accessToken)
        {
            var appointments = await _appointmentRepository.GetAppointmentsByPatientIdAsync(patientId);

            var doctorsIds = appointments.Select(doc => doc.DoctorId).Distinct();

            var httpClient = new HttpClientWrapper(_httpClient, accessToken, _configuration);

            var doctors = await httpClient.GetEntities<DoctorDTO>(doctorsIds);
            var appointmentsView = _mapper.Map<IEnumerable<AppointmentViewDTO>>(appointments);

            foreach (var app in appointmentsView)
            {
                app.Doctor = doctors.FirstOrDefault(doc => app.Doctor.Id.Equals(doc.Id));
            }

            return appointmentsView;
        }

        public async Task<IEnumerable<AppointmentViewDTO>> ViewAppointmentScheduleByDoctorAsync(Guid doctorId, string accessToken)
        {
            var appointments = await _appointmentRepository.GetAppointmentsByDoctorIdAsync(doctorId);

            var patientsIds = appointments.Select(pat => pat.PatientId).Distinct();

            var httpClient = new HttpClientWrapper(_httpClient, accessToken, _configuration);

            var patients = await httpClient.GetEntities<PatientDTO>(patientsIds);
            var appointmentsView = _mapper.Map<IEnumerable<AppointmentViewDTO>>(appointments);

            foreach (var app in appointmentsView)
            {
                app.Patient = patients.FirstOrDefault(pat => app.Patient.Id.Equals(pat.Id));
            }

            return appointmentsView;
        }

        public async Task<IEnumerable<DateWithTimeSlots>> GetTimeSlotsAsync(Guid doctorId)
        {
            var appointments = await _appointmentRepository.GetAppointmentsByDoctorForWeekAsync(doctorId);
            var appointmentsDto = _mapper.Map<IEnumerable<AppointmentDTO>>(appointments).ToList();

            return TimeSlots.GetTimeSlotsWithReservedTime(appointmentsDto);
        }
    }
}
