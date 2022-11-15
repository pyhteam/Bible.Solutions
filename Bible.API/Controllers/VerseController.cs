using Bible.API.Controllers.Base;
using Bible.DTOs.Queries;
using Bible.Service.Services.VerseServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bible.API.Controllers
{
    public class VerseController : BaseController<IVerseService>
    {
        public VerseController(IVerseService service) : base(service)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetVerse()
        {
            var verses = await _service.GetAllAsync();
            return GetResponse(verses);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVerse(int id)
        {
            var verse = await _service.GetByIdAsync(id);
            if (verse == null)
            {
                return NotFound();
            }
            return GetResponse(verse);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVerse(int id, VerseQuery verse)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            try
            {
                int result = await _service.UpdateAsync(verse, id);
                if (result == 0)
                {
                    return GetResponseError("Update failed");
                }
                return GetResponse(verse);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _service.GetByIdAsync(id) != null)
                {
                    return GetResponseError("verse not found");
                }
                else
                {
                    throw;
                }
            }
        }
        [HttpPost]
        public async Task<IActionResult> PostVerse(VerseQuery verse)
        {
            if (verse == null)
            {
                return BadRequest();
            }
            bool result = await _service.CreateAsync(verse);
            if (result == false)
            {
                return GetResponseError("Create failed");
            }
            return GetResponse(verse);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVerse(int id)
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
