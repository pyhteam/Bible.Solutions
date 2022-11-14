using Bible.API.Controllers.Base;
using Bible.DTOs.Queries;
using Bible.Service.Services.BiblesServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bible.API.Controllers
{
    public class BiblesController : BaseController<IBiblesService>
    {
        public BiblesController(IBiblesService service) : base(service)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetBibles()
        {
            var bibles = await _service.GetAllAsync();
            return GetResponse(bibles);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBibles(int id)
        {
            var bible = await _service.GetByIdAsync(id);
            if (bible == null)
            {
                return NotFound();
            }
            return GetResponse(bible);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBibles(int id, BiblesQuery bible)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            try
            {
                int result = await _service.UpdateAsync(bible, id);
                if (result == 0)
                {
                    return GetResponseError("Update failed");
                }
                return GetResponse(bible);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _service.GetByIdAsync(id) != null)
                {
                    return GetResponseError("bible not found");
                }
                else
                {
                    throw;
                }
            }
        }
        [HttpPost]
        public async Task<IActionResult> PostBibles(BiblesQuery bible)
        {
            if (bible == null)
            {
                return BadRequest();
            }
            bool result = await _service.CreateAsync(bible);
            if (result == false)
            {
                return GetResponseError("Create failed");
            }
            return GetResponse(bible);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBibles(int id)
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
