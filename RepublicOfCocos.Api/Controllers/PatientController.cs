using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RepublicOfCocos.Core.DTOs;
using RepublicOfCocos.Core.Entities;
using RepublicOfCocos.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepublicOfCocos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;
        public PatientController(IPatientRepository patientRepository, IMapper mapper)
        {
             _patientRepository = patientRepository;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetPatients()
        {
            var patients = await _patientRepository.GetPatients();
            var patientsDTO = _mapper.Map<IEnumerable<PatientDTO>>(patients);

            return Ok(patientsDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatient(long id)
        {
            var patient = await _patientRepository.GetPatient(id);
            var patientDTO = _mapper.Map<PatientDTO>(patient);
            return Ok(patientDTO);
        }

        [HttpPost]
        public async Task<IActionResult> InsertPatients(PatientDTO patientDTO)
        {
            var patient = _mapper.Map<Patient>(patientDTO);
            await _patientRepository.InsertPatients(patient);
            return Ok(patient);
        }
    }
}
