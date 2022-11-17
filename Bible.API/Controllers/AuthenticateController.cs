using Bible.API.Controllers.Base;
using Bible.DTOs.Queries;
using Bible.Service.Services.UserServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bible.API.Controllers
{
    public class AuthenticateController : BaseController<IUserService>
    {
        public AuthenticateController(IUserService service) : base(service)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Authenticate([FromBody] LoginQuery user)
        {
            if (ModelState.IsValid)
            {
                var result = await _service.Login(user);
                if (result == null)
                {
                    return GetResponseError("Username or password is incorrect");
                }
                return GetResponse(result, "Login success");
            }
            return GetResponseError(ModelState.Values.First().Errors.First().ErrorMessage);

        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterQuery user)
        {
            if (ModelState.IsValid)
            {
                var result = await _service.Register(user);
                if (result == null)
                {
                    return GetResponseError("Register failed");
                }
                return GetResponse(result, "Register success");
            }
            return GetResponseError(ModelState.Values.First().Errors.First().ErrorMessage);
        }
    }
}
