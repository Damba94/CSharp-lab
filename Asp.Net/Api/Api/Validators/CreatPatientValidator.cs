using Api.Dtos;
using FluentValidation;

namespace Api.Validators
{
    public class CreatPatientValidator:AbstractValidator<CreatePatientRequest>
    {
        public CreatPatientValidator()
        {
            RuleFor(x => x.OIB)
                .Length(11)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.MBO)
                .Length(9)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.FullName)
                .MaximumLength(30)
                .NotEmpty()
                .NotNull();

        }
    }
}
