using AutoMapper;
using InnoClinic.AppointmentsAPI.Application.DataTransferObjects;
using InnoClinic.AppointmentsAPI.Application.Services.Abstractions;
using InnoClinic.AppointmentsAPI.Core.Contracts.Repositories;
using InnoClinic.AppointmentsAPI.Core.Entitites.Models;
using InnoClinic.AppointmentsAPI.Core.Exceptions;
using InnoClinic.AppointmentsAPI.Core.Exceptions.UserExceptions;

namespace InnoClinicAPI.AppointmentsAPI.Application.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IMapper _mapper;

        public AppointmentService(IAppointmentRepository appointmentRepository, IMapper mapper)
        {
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
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

        public async Task<IEnumerable<AppointmentDTO>> GetAllAppointmentsAsync()
        {
            var appointmentsCollection = await _appointmentRepository.GetAllAppointmentsAsync();

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

    }
}
