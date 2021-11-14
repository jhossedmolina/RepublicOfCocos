using System.Collections.Generic;

namespace RepublicOfCocos.Infraestructure.Validators
{
    public class TriageValidator : ITriageValidator
    {
        public bool CorrectTriage(string triage)
        {
            bool correct = true;
            List<string> correctTriage = new List<string>() { "Atención inmediata", "Riesgo vital", "Urgencia menor",
                                                              "No urgencia"};

            if (!correctTriage.Contains(triage)) return false;

            return correct;
        }
    }
}
