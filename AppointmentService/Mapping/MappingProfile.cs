using AppointmentService.DTOs;
using AppointmentService.Models;
using AutoMapper;

namespace AppointmentService.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Appointment, AppointmentDTO>();
            CreateMap<AppointmentDTO, Appointment>();
        }
    }
}