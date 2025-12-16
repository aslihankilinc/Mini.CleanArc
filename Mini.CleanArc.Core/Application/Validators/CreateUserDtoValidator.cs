using FluentValidation;
using Mini.CleanArc.Core.Application.Models.UserDto;

public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
{
    //API’ye hatalı veri girilmesini engeller
    public CreateUserDtoValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        //RuleFor(x => x.Role).NotEmpty();
    }
}
