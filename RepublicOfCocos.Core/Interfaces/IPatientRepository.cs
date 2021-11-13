using RepublicOfCocos.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepublicOfCocos.Core.Interfaces
{
    public interface IPatientRepository
    {
        Task<IEnumerable<Patient>> GetPatients();
    }
}
