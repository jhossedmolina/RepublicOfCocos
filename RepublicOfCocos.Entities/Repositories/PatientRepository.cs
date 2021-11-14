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

        public async Task<bool> UpdatePatient(Patient patient)
        {
            var currentPatient = await GetPatient(patient.PatientId);
            currentPatient.PatientId = patient.PatientId;
            currentPatient.Name = patient.Name;
            currentPatient.Age = patient.Age;
            currentPatient.Gender = patient.Gender;
            currentPatient.Symptom = patient.Symptom;

            int  rows = await _context.SaveChangesAsync();
            return rows > 0;         
        }

        public async Task<bool> DeletePatient(long id)
        {
            var result = await GetPatient(id);

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
