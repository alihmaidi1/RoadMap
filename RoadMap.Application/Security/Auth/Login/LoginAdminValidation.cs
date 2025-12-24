using FluentValidation;

namespace RoadMap.Application.Security.Auth.Login;

internal sealed class LoginAdminValidation: AbstractValidator<LoginAdminCommand>
{
    public LoginAdminValidation()
    {

        RuleFor(x => x.UserName)
            .NotEmpty()
            .NotNull();
        RuleFor(x=>x.Password)
            .NotEmpty()
            .NotNull();
    }
}