using AtlasConnectionApiCode.Dto.Request;
using FluentValidation;

namespace AtlasConnectionApiCode.Validation
{
    public class SaveUserDtoRequestValidation : AbstractValidator<SaveUserDtoRequest>
    {
        public SaveUserDtoRequestValidation()
        {
            RuleFor(x => x.Id)
                .Must(ValidateId)
                .WithErrorCode("E1001")
                .WithMessage("Invalid Id, must have 24 characters");

            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .Length(5, 50)
                .WithErrorCode("E1002")
                .WithMessage("Invalid Name, length between 5 and 50 charcaters");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .NotNull()
                .Length(5, 50)
                .WithErrorCode("E1003")
                .WithMessage("Invalid LastName, length between 5 and 50 charcaters");

            RuleForEach(x => x.PhoneNumbers)
                .SetValidator(new PhoneNumberValidation());

            RuleForEach(x => x.Directions)
                .SetValidator(new DirectionValidation());
        }

        private bool ValidateId(string? id)
        {
            if (string.IsNullOrEmpty(id)) return true;
            else return id.Length == 24;
        }
    }

    public class PhoneNumberValidation : AbstractValidator<PhoneNumber>
    {
        public PhoneNumberValidation()
        {
            RuleFor(x => x.Number)
                .NotNull()
                .NotEmpty()
                .Length(9)
                .WithErrorCode("E1004")
                .WithMessage("Invalid Phone Number, length must be 9 charcaters");

            RuleFor(x => x.NumberType)
                .NotNull()
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(9)
                .WithErrorCode("E1005")
                .WithMessage("Invalid Phone NumberType, length must be between 5 to 9 charcaters");
        }
    }
    public class DirectionValidation : AbstractValidator<Direction>
    {
        public DirectionValidation()
        {
            RuleFor(x => x.Address)
                .NotNull()
                .NotEmpty()
                .MaximumLength(50)
                .WithErrorCode("E1006")
                .WithMessage("Invalid Direction Address, max length 50 charcaters");

            RuleFor(x => x.Country)
                .NotNull()
                .NotEmpty()
                .MaximumLength(20)
                .WithErrorCode("E1007")
                .WithMessage("Invalid Direction Country, max length 20 charcaters");

            RuleFor(x => x.City)
                .NotNull()
                .NotEmpty()
                .MaximumLength(20)
                .WithErrorCode("E1008")
                .WithMessage("Invalid Direction City, max length 20 charcaters");

            RuleFor(x => x.DirectionType)
                .NotNull()
                .NotEmpty()
                .MaximumLength(20)
                .WithErrorCode("E1009")
                .WithMessage("Invalid Direction DirectionType, max length 20 charcaters");
        }
    }
}
