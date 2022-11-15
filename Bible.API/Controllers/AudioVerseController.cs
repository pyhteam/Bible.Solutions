using Bible.API.Controllers.Base;
using Bible.DTOs.Queries;
using Bible.Service.Services.AudioVerseServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bible.API.Controllers
{
    public class AudioVerseController : BaseController<IAudioVerseService>
    {
        public AudioVerseController(IAudioVerseService service) : base(service)
        {
        }
        [HttpGet]
        public async Task<IActionResult> GetAudioVerse()
        {
            var audioVerses = await _service.GetAllAsync();
            return GetResponse(audioVerses);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAudioVerse(int id)
        {
            var audioVerse = await _service.GetByIdAsync(id);
            if (audioVerse == null)
            {
                return NotFound();
            }
            return GetResponse(audioVerse);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAudioVerse(int id, AudioVerseQuery audioVerse)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            try
            {
                int result = await _service.UpdateAsync(audioVerse, id);
                if (result == 0)
                {
                    return GetResponseError("Update failed");
                }
                return GetResponse(audioVerse);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _service.GetByIdAsync(id) != null)
                {
                    return GetResponseError("audioVerse not found");
                }
                else
                {
                    throw;
                }
            }
        }
        [HttpPost]
        public async Task<IActionResult> PostAudioVerse(AudioVerseQuery audioVerse)
        {
            if (audioVerse == null)
            {
                return BadRequest();
            }
            bool result = await _service.CreateAsync(audioVerse);
            if (result == false)
            {
                return GetResponseError("Create failed");
            }
            return GetResponse(audioVerse);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAudioVerse(int id)
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
