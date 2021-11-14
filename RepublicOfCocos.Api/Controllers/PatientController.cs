using Microsoft.AspNetCore.Mvc;
using RepublicOfCocos.Core.Entities;
using RepublicOfCocos.Core.Interfaces;
using System.Threading.Tasks;

namespace RepublicOfCocos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepository _patientRepository;
        public PatientController(IPatientRepository patientRepository)
        {
             _patientRepository = patientRepository;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetPatients()
        {
            var patients = await _patientRepository.GetPatients();
            return Ok(patients);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatient(long id)
        {
            var patient = await _patientRepository.GetPatient(id);
            return Ok(patient);
        }

        [HttpPost]
        public async Task<IActionResult> InsertPatients(Patient patients)
        {
            await _patientRepository.InsertPatients(patients);
            return Ok(patients);
        }
    }
}
