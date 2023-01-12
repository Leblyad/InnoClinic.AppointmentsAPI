using AutoMapper;
using InnoClinic.AppointmentsAPI.Application.DataTransferObjects;
using InnoClinic.AppointmentsAPI.Core.Entitites.Models;

namespace InnoClinic.AppointmentsAPI.Application.MappingProfiles
{
    public class ResultMappingProfile : Profile
    {
        public ResultMappingProfile()
        {
            CreateMap<Result, ResultDTO>();

            CreateMap<ResultForCreationDTO, Result>();

            CreateMap<ResultForUpdateDTO, Result>().ReverseMap();
        }
    }
}
