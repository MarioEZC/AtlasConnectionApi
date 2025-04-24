using AtlasConnectionApiCode.Dto.Request;
using FluentValidation;

namespace AtlasConnectionApiCode.Validation
{
    public class DeleteUserDtoRequestValidation: AbstractValidator<DeleteUserDtoRequest>
    {
        public DeleteUserDtoRequestValidation()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull()
                .Length(24)
                .WithErrorCode("E1011")
                .WithMessage("Invalid Id, length must be 24 charcaters");
        }
    }
}
