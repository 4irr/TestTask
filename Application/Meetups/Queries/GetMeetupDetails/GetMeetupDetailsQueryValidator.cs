using FluentValidation;

namespace Application.Meetups.Queries.GetMeetupDetails
{
    public class GetMeetupDetailsQueryValidator : AbstractValidator<GetMeetupDetailsQuery>
    {
        public GetMeetupDetailsQueryValidator() 
        {
            RuleFor(query => query.Id)
                .NotEqual(Guid.Empty).WithMessage("Обязательное поле");
        }
    }
}
