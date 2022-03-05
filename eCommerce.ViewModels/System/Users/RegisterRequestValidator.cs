using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.ViewModels.System.Users
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("FirstName is required")
                                     .MaximumLength(200).WithMessage("FirstName can not over 200 characters");

            RuleFor(x => x.LastName).NotEmpty().WithMessage("LastName is required")
                                     .MaximumLength(200).WithMessage("LastName can not over 200 characters");

            RuleFor(x => x.Birthday).GreaterThan(DateTime.Now.AddYears(-100)).WithMessage("Birthday can not greater 100 years");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required")
                                 .Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").WithMessage("Email format not match ");

            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Phone Number not null");

            RuleFor(x => x.Username).NotEmpty().WithMessage("UserName required");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Password required")
                                    .MinimumLength(6).WithMessage("Password is at least 6 characters");

            RuleFor(x => x).Custom((request, context) =>
            {
                if (request.Password != request.ConfirmPassword)
                {
                    context.AddFailure("Comfirm password is not match");
                }
            });
        }
    }
}