using RepublicOfCocos.Core.Entities;
using RepublicOfCocos.Core.Exceptions;
using RepublicOfCocos.Core.Interfaces;
using RepublicOfCocos.Infraestructure.Validators;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepublicOfCocos.Core.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly ITriageValidator _triageValidator;

        public PatientService(IPatientRepository patientRepository, ITriageValidator triageValidator)
        {
            _patientRepository = patientRepository;
            _triageValidator = triageValidator;
        }

        public async Task<IEnumerable<Patient>> GetPatients()
        {
            return await _patientRepository.GetPatients();
        }

        public async Task<Patient> GetPatient(long id)
        {
            return await _patientRepository.GetPatient(id);
        }

        public async Task InsertPatients(Patient patients)
        {
            if (!_triageValidator.CorrectTriage(patients.Triage))
            {
                throw new GlobalException($"El Triage {patients.Triage} no existe. " +
                    $"Solo puede ingresar: Atención inmediata, Riesgo vital, Urgencia menor o No urgencia");
            }

            await _patientRepository.InsertPatients(patients);
        }

        public async Task<bool> UpdatePatient(Patient patient)
        {
            return await _patientRepository.UpdatePatient(patient);
        }

        public async Task<bool> DeletePatient(long id)
        {
            return await _patientRepository.DeletePatient(id);
        } 
    }
}
