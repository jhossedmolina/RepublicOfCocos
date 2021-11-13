using Microsoft.AspNetCore.Mvc;
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
            var patient = await _patientRepository.GetPatients();
            return Ok(patient);
        }
    }
}
