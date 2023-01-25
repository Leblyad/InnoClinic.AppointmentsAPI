using AutoMapper;
using InnoClinic.AppointmentsAPI.Application.DataTransferObjects;
using InnoClinic.AppointmentsAPI.Application.DataTransferObjects.Views;
using InnoClinic.AppointmentsAPI.Core.Entitites.Models;

namespace InnoClinic.AppointmentsAPI.Application.MappingProfiles
{
    public class AppointmentMappingProfile : Profile
    {
        public AppointmentMappingProfile()
        {
            CreateMap<Appointment, AppointmentDTO>().ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date.Date.ToString("dd/MM/yyyy")));

            CreateMap<AppointmentForCreationDTO, Appointment>();

            CreateMap<AppointmentForUpdateDTO, Appointment>().ReverseMap();

            CreateMap<Appointment, AppointmentViewDTO>()
                .ForPath(dest => dest.Patient.Id, opt => opt.MapFrom(src => src.PatientId))
                .ForPath(dest => dest.Doctor.Id, opt => opt.MapFrom(src => src.DoctorId));
        }
    }
}
