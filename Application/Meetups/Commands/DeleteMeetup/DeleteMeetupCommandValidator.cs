using FluentValidation;

namespace Application.Meetups.Commands.DeleteMeetup
{
    public class DeleteMeetupCommandValidator : AbstractValidator<DeleteMeetupCommand>
    {
        public DeleteMeetupCommandValidator() 
        {
            RuleFor(command => command.Id)
                .NotEqual(Guid.Empty).WithMessage("Обязательное поле");
        }
    }
}
