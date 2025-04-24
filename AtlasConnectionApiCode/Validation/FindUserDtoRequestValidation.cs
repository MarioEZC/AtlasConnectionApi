using AtlasConnectionApiCode.Dto.Request;
using FluentValidation;

namespace AtlasConnectionApiCode.Validation
{
    public class FindUserDtoRequestValidation : AbstractValidator<FindUserDtoRequest>
    {
        public FindUserDtoRequestValidation()
        {
            RuleFor(x => x.Id)
                .Must(ValidateId)
                .WithErrorCode("E1010")
                .WithMessage("Invalid Id, length must be 0 or 24 charcaters");

        }

        private bool ValidateId(string? id)
        {
            if (string.IsNullOrEmpty(id)) return true;
            else return id.Length == 24;
        }
    }
}
