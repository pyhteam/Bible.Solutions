using Bible.API.Controllers.Base;
using Bible.DTOs.Queries;
using Bible.Service.Services.PartServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bible.API.Controllers
{
    public class PartController : BaseController<IPartService>
    {
        public PartController(IPartService service) : base(service)
        {
        }
        [HttpGet]
        public async Task<IActionResult> GetPart()
        {
            var parts = await _service.GetAllAsync();
            return GetResponse(parts);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPart(int id)
        {
            var part = await _service.GetByIdAsync(id);
            if (part == null)
            {
                return NotFound();
            }
            return GetResponse(part);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPart(int id, PartQuery part)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            try
            {
                int result = await _service.UpdateAsync(part, id);
                if (result == 0)
                {
                    return GetResponseError("Update failed");
                }
                return GetResponse(part);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _service.GetByIdAsync(id) != null)
                {
                    return GetResponseError("part not found");
                }
                else
                {
                    throw;
                }
            }
        }
        [HttpPost]
        public async Task<IActionResult> PostPart(PartQuery part)
        {
            if (part == null)
            {
                return BadRequest();
            }
            bool result = await _service.CreateAsync(part);
            if (result == false)
            {
                return GetResponseError("Create failed");
            }
            return GetResponse(part);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePart(int id)
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
