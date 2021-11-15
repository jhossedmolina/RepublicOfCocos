using AutoMapper;
using RepublicOfCocos.Core.DTOs;
using RepublicOfCocos.Core.Entities;

namespace RepublicOfCocos.Infraestructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Patient, PatientDTO>();
            CreateMap<PatientDTO, Patient>();
            CreateMap<Surgery, SurgeryDTO>();
            CreateMap<SurgeryDTO, Surgery>();
        }
    }
}
