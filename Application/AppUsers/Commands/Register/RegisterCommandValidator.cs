using Domain;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace Application.AppUsers.Commands.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        private readonly UserManager<AppUser>? _userManager;

        public RegisterCommandValidator(UserManager<AppUser> userManager) 
        {
            _userManager = userManager;

            RuleFor(command => command.Username)
                .NotEmpty().WithMessage("Обязательно поле")
                .Must(IsUsernameUnique).WithMessage("Пользователь с таким логином уже зарегистрирован");
            RuleFor(command => command.Password)
                .NotEmpty().WithMessage("Обязательно поле");
            RuleFor(command => command.PasswordConfirm)
                .NotEmpty().WithMessage("Обязательно поле")
                .Must((command, value) => value == command.Password).WithMessage("Пароли не совпадают");
            RuleFor(command => command.DisplayName)
                .NotEmpty().WithMessage("Обязательно поле");
        }

        private bool IsUsernameUnique(string? username)
        {
            return (_userManager?.Users.FirstOrDefault(u => u.UserName == username) != null) ? false : true;
        }
    }
}
