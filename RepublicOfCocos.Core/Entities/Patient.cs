
namespace RepublicOfCocos.Core.Entities
{
    public partial class Patient
    {
        public long PatientId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Triage { get; set; }
        public string Symptom { get; set; }
    }
}
