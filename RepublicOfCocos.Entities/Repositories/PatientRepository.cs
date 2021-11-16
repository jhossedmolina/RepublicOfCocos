using Microsoft.EntityFrameworkCore;
using RepublicOfCocos.Core.Entities;
using RepublicOfCocos.Core.Interfaces;
using RepublicOfCocos.Infraestructure.Data;
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
            
            List<Patient> patientList1 = new List<Patient>();
            List<Patient> patientList2 = new List<Patient>();
            List<Patient> patientList3 = new List<Patient>();
            List<Patient> patientList4 = new List<Patient>();

            foreach (var element in patients)
            {
                if(element.Triage.Contains("Atención inmediata"))
                {
                    patientList1.Add(element);
                }
                    

                else if (element.Triage.Contains("Riesgo vital")) patientList2.Add(element);

                else if (element.Triage.Contains("Urgencia menor")) patientList3.Add(element);

                else if (element.Triage.Contains("No urgencia")) patientList4.Add(element);
            }

            var patientList = patientList1.Concat(patientList2).Concat(patientList3).Concat(patientList4);
            return patientList;
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
            _context.Patient.Remove(result);

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
