using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bible.Database.Data;
using Bible.Database.Entities;
using Bible.Service.Services.LanguageServices;
using Bible.DTOs.Queries;
using Bible.API.Controllers.Base;

namespace Bible.API.Controllers
{

    public class LanguagesController : BaseController<ILanguageService>
    {
        public LanguagesController(ILanguageService service) : base(service)
        {
        }

        // GET: api/Languages
        [HttpGet]
        public async Task<IActionResult> GetLanguages()
        {
            var languages = await _service.GetAllAsync();
            return GetResponse(languages);
        }

        // GET: api/Languages/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLanguage(int id)
        {
            var language = await _service.GetByIdAsync(id);
            if (language == null)
            {
                return NotFound();
            }
            return GetResponse(language);
        }

        // PUT: api/Languages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLanguage(int id, LanguageQuery language)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            try
            {
                int result = await _service.UpdateAsync(language, id);
                if (result == 0)
                {
                    return GetResponseError("Update failed");
                }
                return GetResponse(language);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _service.GetByIdAsync(id) != null)
                {
                    return GetResponseError("Language not found");
                }
                else
                {
                    throw;
                }
            }
        }

        // POST: api/Languages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostLanguage(LanguageQuery language)
        {
            if (language == null)
            {
                return BadRequest();
            }
            bool result = await _service.CreateAsync(language);
            if (result == false)
            {
                return GetResponseError("Create failed");
            }
            return GetResponse(language);
        }

        // DELETE: api/Languages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLanguage(int id)
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
