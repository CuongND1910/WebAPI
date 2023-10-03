using Microsoft.AspNetCore.Identity;
using MyWebAPINet6.Model;

namespace MyWebAPINet6.Repositories
{
    public interface IAccountRepository
    {
        public Task<IdentityResult> SignUpAsync(SignUpModel model);
        public Task<string> SignInAsync(SignInModel model);
    }
}
