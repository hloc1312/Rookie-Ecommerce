using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.ViewModels.System.Users
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("UserName required");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Password required")
                                    .MinimumLength(6).WithMessage("Password is at least 6 characters");
        }
    }
}