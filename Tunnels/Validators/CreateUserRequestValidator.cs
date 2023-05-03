using Tunnels.DTOs.User;
using FluentValidation;

namespace Tunnels.Validators
{
    public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserRequestValidator()
        {
            RuleFor(a => a.Name)
                .NotNull()
                .WithMessage("Name is required");
        }
    }
}
