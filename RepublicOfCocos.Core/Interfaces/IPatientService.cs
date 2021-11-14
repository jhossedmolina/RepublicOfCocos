using RepublicOfCocos.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepublicOfCocos.Core.Interfaces
{
    public interface IPatientService
    {
        Task<IEnumerable<Patient>> GetPatients();
        Task<Patient> GetPatient(long id);
        Task InsertPatients(Patient patients);
        Task<bool> UpdatePatient(Patient patient);
        Task<bool> DeletePatient(long id);
    }
}