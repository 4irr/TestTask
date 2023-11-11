using FluentValidation;

namespace Application.Meetups.Commands.UpdateMeetup
{
    public class UpdateMeetupCommandValidator : AbstractValidator<UpdateMeetupCommand>
    {
        public UpdateMeetupCommandValidator()
        {
            RuleFor(command => command.Id)
                .NotEqual(Guid.Empty).WithMessage("Обязательное поле");
            RuleFor(command => command.Name)
                .NotEmpty().WithMessage("Обязательное поле")
                .MinimumLength(5).WithMessage("Длина строки наименования события не должна быть меньше 5 символов");
            RuleFor(command => command.Description)
                .NotEmpty().WithMessage("Обязательное поле")
                .MaximumLength(250).WithMessage("Максимальная длина описания - 250 символов");
            RuleFor(command => command.Speaker)
                .NotEmpty().WithMessage("Обязательное поле");
            RuleFor(command => command.DateTime)
                .NotEmpty().WithMessage("Обязательное поле")
                .Must(value => value > DateTime.Now).WithMessage("Некорректное значение даты");
            RuleFor(command => command.Place)
                .NotEmpty().WithMessage("Обязательное поле");
        }
    }
}
