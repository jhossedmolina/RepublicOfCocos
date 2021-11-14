using FluentValidation;
using RepublicOfCocos.Core.DTOs;

namespace RepublicOfCocos.Infraestructure.Validators
{
    public class PatientValidator : AbstractValidator<PatientDTO>
    {
        public PatientValidator()
        {
            RuleFor(patient => patient.PatientId)
                .NotNull()
                .LessThanOrEqualTo(9999999999);

            RuleFor(patient => patient.Name)
                .NotNull()
                .Length(20, 50);

            RuleFor(patient => patient.Age)
                .NotNull()
                .LessThanOrEqualTo(99);

            RuleFor(patient => patient.Gender)
                .NotNull()
                .MaximumLength(10);

            RuleFor(patient => patient.Triage)
                .NotNull();

            RuleFor(patient => patient.Symptom)
                .NotNull();
        }
    }
}
