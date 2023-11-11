using FluentValidation;

namespace Application.AppUsers.Queries.Login
{
    public class LoginQueryValidator : AbstractValidator<LoginQuery>
    {
        public LoginQueryValidator() 
        {
            RuleFor(query => query.UserName)
                .NotEmpty().WithMessage("Обязательное поле");
            RuleFor(query => query.Password)
                .NotEmpty().WithMessage("Обязательное поле");
        }
    }
}
