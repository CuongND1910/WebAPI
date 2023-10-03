using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyWebAPINet6.Model;
using MyWebAPINet6.Repositories;

namespace MyWebAPINet6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountRepository accountRepo;

        public AccountsController(IAccountRepository repo)
        {
            accountRepo = repo;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(SignUpModel model)
        {
            var result = await accountRepo.SignUpAsync(model);
            if (result.Succeeded)
            {
                return Ok(result.Succeeded);
            }
            return Unauthorized();
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(SignInModel model)
        {
            var result = await accountRepo.SignInAsync(model);
            if (string.IsNullOrEmpty(result))
            {
                return Unauthorized();
            }
            return Ok(result);
        }
    }
}
