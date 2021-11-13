using RepublicOfCocos.Core.Entities;
using RepublicOfCocos.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepublicOfCocos.Infraestructure.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        public async Task<IEnumerable<Patient>> GetPatients()
        {
            var patients = Enumerable.Range(1, 10).Select(x => new Patient
            {
                PatientID = x,
                Name = "Jhossed Molina",
                Age = 22,
                Gender = "Male",
                Symptom = $"Symptom {x}",
                Triage = $"Triage {x}"
            });

            await Task.Delay(10);

            return patients;
        }
    }
}
