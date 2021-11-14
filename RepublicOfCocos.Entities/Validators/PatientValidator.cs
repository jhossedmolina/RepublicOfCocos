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
                .NotEmpty()
                .LessThanOrEqualTo(9999999999);

            RuleFor(patient => patient.Name)
                .NotNull()
                .NotEmpty()
                .Length(10, 50);

            RuleFor(patient => patient.Age)
                .NotNull()
                .NotEmpty()
                .LessThanOrEqualTo(99);

            RuleFor(patient => patient.Gender)
                .NotNull()
                .NotEmpty()
                .MaximumLength(10);

            RuleFor(patient => patient.Triage)
                .NotNull()
                .NotEmpty();

            RuleFor(patient => patient.Symptom)
                .NotNull()
                .NotEmpty();
        }
    }
}
