using CoreIdentity.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace CoreIdentity.Infrastructure
{
    public class CustomUserValidator : IUserValidator<ApplicationUser>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<ApplicationUser> manager, ApplicationUser user)
        {
            if (user.Email.ToLower().EndsWith("@gmail.com") || user.Email.ToLower().EndsWith("@mail.ru"))
            {
                return Task.FromResult(IdentityResult.Success);
            }
            else
            {
                return Task.FromResult(IdentityResult.Failed(new IdentityError()
                {
                    Code = "EmailDomainError",
                    Description = "Sadece @gmail.com ve @mail.ru"
                }));
            }
        }
    }
}
