using Bible.API.Controllers.Base;
using Bible.DTOs.Queries;
using Bible.Service.Services.UserServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bible.API.Controllers
{
    [Authorize(Policy = "Admin")]
    public class UserController : BaseController<IUserService>
    {
        public UserController(IUserService service) : base(service)
        {
        }
        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            var users = await _service.GetAllAsync();
            return GetResponse(users);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _service.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return GetResponse(user);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, UserQuery user)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            try
            {
                int result = await _service.UpdateAsync(user, id);
                if (result == 0)
                {
                    return GetResponseError("Update failed");
                }
                return GetResponse(user);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _service.GetByIdAsync(id) != null)
                {
                    return GetResponseError("user not found");
                }
                else
                {
                    throw;
                }
            }
        }
        [HttpPost]
        public async Task<IActionResult> PostUser(UserQuery user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            bool result = await _service.CreateAsync(user);
            if (result == false)
            {
                return GetResponseError("Create failed");
            }
            return GetResponse(user);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            int result = await _service.DeleteAsync(id);
            if (result == 0)
            {
                return GetResponseError("Delete failed");
            }
            return GetResponse(result);
        }
    }
}
