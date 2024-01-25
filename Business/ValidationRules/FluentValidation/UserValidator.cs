using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty();
            RuleFor(u => u.FirstName).Length(3, 30);
            RuleFor(u => u.LastName).NotEmpty();
            RuleFor(u => u.LastName).Length(3, 30);
            RuleFor(u => u.Email).NotEmpty();
            RuleFor(u => u.Email).Length(8, 35);
            RuleFor(u => u.Email).Must(Contains).WithMessage("Email '@' sembolü içermelidir.");
            RuleFor(u => u.Email).Must(EndWithCom).WithMessage("Email '.com' ile bitmelidir.");
            RuleFor(u => u.Password).NotEmpty();
            RuleFor(u => u.Password).Length(5,20);
        }

        private bool EndWithCom(string arg)
        {
            return arg.EndsWith(".com");
        }

        private bool Contains(string arg)
        {
            return arg.Contains("@");
        }
    }
}
