using FluentValidation;
using HatirlaticiAPI.Application.ViewModels.Users;


namespace HatirlaticiAPI.Application.Validators.Users
{
    public class CreateUsersValidators : AbstractValidator<Vm_Create_User>
    {
        public CreateUsersValidators()
        {
            RuleFor(p => p.UserName)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Kullanıcı adı giriniz.")
                .MaximumLength(50)
                .MinimumLength(2)
                    .WithMessage("Kullanıcı adını 2 karakterden büyük, 30 karakterden küçük giriniz.");
            RuleFor(p => p.Password)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Şifre giriniz.")
                .MaximumLength(30)
                .MinimumLength(10)
                    .WithMessage("Şifreninizi 10 karakterden büyük, 30 karakterden küçük giriniz.");
            RuleFor(p => p.Email)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Email giriniz.");
            RuleFor(p => p.DateOfBrith)
                 .NotEmpty()
                 .NotNull()
                    .WithMessage("Doğum Tarihinizi giriniz.");
        }
    }
}
