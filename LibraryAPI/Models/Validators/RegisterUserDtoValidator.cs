using FluentValidation;
using LibraryAPI.Entities;
using System.Linq;

namespace LibraryAPI.Models.Validators
{
    public class RegisterUserDtoValidator : AbstractValidator<RegisterAccountDto>
    {
        public RegisterUserDtoValidator(LibraryDbContext dbContext) 
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(6);

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty().WithMessage("The 'Confirm password' cannot be empty.")
                .Equal(p => p.Password).WithMessage("The passwords are different");

            RuleFor(x => x.Email)
                .Custom((value, context) =>
                {
                    var emailInUse = dbContext.Accounts.Any(a => a.Email == value);
                    if (emailInUse)
                    {
                        context.AddFailure("Email", "That email is taken");
                    }
                });
        }
    }
}
