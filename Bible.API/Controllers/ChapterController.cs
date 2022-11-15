
using Bible.API.Controllers.Base;
using Bible.DTOs.Queries;
using Bible.Service.Services.ChapterServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bible.API.Controllers
{
    public class ChapterController : BaseController<IChapterService>
    {
        public ChapterController(IChapterService service) : base(service)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetChapter()
        {
            var chapters = await _service.GetAllAsync();
            return GetResponse(chapters);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetChapter(int id)
        {
            var chapter = await _service.GetByIdAsync(id);
            if (chapter == null)
            {
                return NotFound();
            }
            return GetResponse(chapter);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChapter(int id, ChapterQuery chapter)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            try
            {
                int result = await _service.UpdateAsync(chapter, id);
                if (result == 0)
                {
                    return GetResponseError("Update failed");
                }
                return GetResponse(chapter);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _service.GetByIdAsync(id) != null)
                {
                    return GetResponseError("chapter not found");
                }
                else
                {
                    throw;
                }
            }
        }
        [HttpPost]
        public async Task<IActionResult> PostChapter(ChapterQuery chapter)
        {
            if (chapter == null)
            {
                return BadRequest();
            }
            bool result = await _service.CreateAsync(chapter);
            if (result == false)
            {
                return GetResponseError("Create failed");
            }
            return GetResponse(chapter);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChapter(int id)
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
