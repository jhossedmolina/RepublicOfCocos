using AutoMapper;
using RepublicOfCocos.Core.DTOs;
using RepublicOfCocos.Core.Entities;

namespace RepublicOfCocos.Infraestructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Patient, PatientDTO>().ReverseMap();

            CreateMap<Surgery, SurgeryDTO>().ReverseMap();

            CreateMap<Security, SecurityDTO>().ReverseMap();
        }
    }
}
