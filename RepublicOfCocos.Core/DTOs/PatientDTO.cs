using System;
using System.Collections.Generic;
using System.Text;

namespace RepublicOfCocos.Core.DTOs
{
    public class PatientDTO
    {
        public long PatientId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Triage { get; set; }
        public string Symptom { get; set; }
    }
}
