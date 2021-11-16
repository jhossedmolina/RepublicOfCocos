using FluentValidation;
using RepublicOfCocos.Core.DTOs;

namespace RepublicOfCocos.Infraestructure.Validators
{
    public class SecurityValidator : AbstractValidator<SecurityDTO>
    {
        public SecurityValidator()
        {
            RuleFor(security => security.RoleUser)
                .NotNull()
                .NotEmpty();

            RuleFor(security => security.PasswordUser)
                .NotNull()
                .NotEmpty();

            RuleFor(security => security.UserName)
                .NotNull()
                .NotEmpty();

            RuleFor(security => security.UserSecurity)
                .NotNull()
                .NotEmpty();

        }
    }
}
