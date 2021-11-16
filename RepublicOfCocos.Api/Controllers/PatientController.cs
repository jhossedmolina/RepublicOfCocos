using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RepublicOfCocos.Api.Responses;
using RepublicOfCocos.Core.DTOs;
using RepublicOfCocos.Core.Entities;
using RepublicOfCocos.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepublicOfCocos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;
        private readonly IMapper _mapper;
        public PatientController(IPatientService patientService, IMapper mapper)
        {
            _patientService = patientService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetPatients()
        {
            var patients = await _patientService.GetPatients();
            var patientsDTO = _mapper.Map<IEnumerable<PatientDTO>>(patients);
            var response = new ApiResponse<IEnumerable<PatientDTO>>(patientsDTO);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatient(long id)
        {
            var patient = await _patientService.GetPatient(id);
            var patientDTO = _mapper.Map<PatientDTO>(patient);
            var response = new ApiResponse<PatientDTO>(patientDTO);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> InsertPatients(PatientDTO patientDTO)
        {
            var patient = _mapper.Map<Patient>(patientDTO);

            await _patientService.InsertPatients(patient);

            patientDTO = _mapper.Map<PatientDTO>(patient);
            var response = new ApiResponse<PatientDTO>(patientDTO);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePatient(long id, PatientDTO patientDTO)
        {
            var patient = _mapper.Map<Patient>(patientDTO);
            patient.PatientId = id;

            var result  = await _patientService.UpdatePatient(patient);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(long id)
        {
            var result = await _patientService.DeletePatient(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}