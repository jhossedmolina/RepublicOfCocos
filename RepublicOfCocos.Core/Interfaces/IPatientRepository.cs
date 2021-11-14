using RepublicOfCocos.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepublicOfCocos.Core.Interfaces
{
    public interface IPatientRepository
    {
        Task<IEnumerable<Patient>> GetPatients();
        Task<Patient> GetPatient(long id);
        Task InsertPatients(Patient patients);
    }
}
