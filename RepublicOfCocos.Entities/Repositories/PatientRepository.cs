using Microsoft.EntityFrameworkCore;
using RepublicOfCocos.Core.Entities;
using RepublicOfCocos.Core.Interfaces;
using RepublicOfCocos.Infraestructure.Data;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepublicOfCocos.Infraestructure.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly RepublicOfCocosDBContext _context;

        public PatientRepository(RepublicOfCocosDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Patient>> GetPatients()
        {
            var patients = await _context.Patient.ToListAsync();
            return patients;
        }

        public async Task<Patient> GetPatient(long id)
        {
            var patient = await _context.Patient.FirstOrDefaultAsync(x => x.PatientId == id);
            return patient;
        }

        public async Task InsertPatients(Patient patients)
        {
            _context.Patient.Add(patients);
            await _context.SaveChangesAsync();
        }
    }
}
