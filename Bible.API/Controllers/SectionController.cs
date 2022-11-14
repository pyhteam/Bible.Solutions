using Bible.API.Controllers.Base;
using Bible.DTOs.Queries;
using Bible.Service.Services.SectionServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bible.API.Controllers
{
    public class SectionController : BaseController<ISectionService>
    {
        public SectionController(ISectionService service) : base(service)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetSections()
        {
            var sections = await _service.GetAllAsync();
            return GetResponse(sections);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSection(int id)
        {
            var section = await _service.GetByIdAsync(id);
            if (section == null)
            {
                return NotFound();
            }
            return GetResponse(section);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSection(int id, SectionQuery section)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            try
            {
                int result = await _service.UpdateAsync(section, id);
                if (result == 0)
                {
                    return GetResponseError("Update failed");
                }
                return GetResponse(section);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _service.GetByIdAsync(id) != null)
                {
                    return GetResponseError("section not found");
                }
                else
                {
                    throw;
                }
            }
        }
        [HttpPost]
        public async Task<IActionResult> PostSection(SectionQuery section)
        {
            if (section == null)
            {
                return BadRequest();
            }
            bool result = await _service.CreateAsync(section);
            if (result == false)
            {
                return GetResponseError("Create failed");
            }
            return GetResponse(section);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSection(int id)
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
