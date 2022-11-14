using Bible.Database.Entities;
using Bible.DTOs.Queries;
using Bible.DTOs.Views;
using Bible.Service.Interfaces;
using Bible.Service.Services.BaseService;
using Microsoft.EntityFrameworkCore;

namespace Bible.Service.Services.LanguageServices
{
    public class LanguageService : ILanguageService
    {
        private readonly IUnitOfWork _unitOfWork;
        public LanguageService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateAsync(LanguageQuery entity)
        {
            Language language = new Language()
            {
                Name = entity.Name,
                Code = entity.Code
            };
            _unitOfWork.GetRepository<Language>().Add(language);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var language = _unitOfWork.GetRepository<Language>().Get(id);
            if (language == null)
            {
                return 0;
            }
            _unitOfWork.GetRepository<Language>().Delete(language);
            return await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<LanguageView>> GetAllAsync()
        {
            var languages = await _unitOfWork.GetRepository<Language>().AsQueryable().Select(x => new LanguageView()
            {
                Id = x.Id,
                Name = x.Name,
                Code = x.Code
            }).ToListAsync();
            return languages;
        }

        public async Task<LanguageView> GetByIdAsync(int id)
        {
            var language = _unitOfWork.GetRepository<Language>().Get(id);
            if (language == null)
            {
                return null;
            }
            return new LanguageView()
            {
                Id = language.Id,
                Name = language.Name,
                Code = language.Code
            };
        }

        public async Task<int> UpdateAsync(LanguageQuery entity, int id)
        {
            if (id == 0)
            {
                return 0;
            }
            var language = _unitOfWork.GetRepository<Language>().Get(id);
            if (language == null)
            {
                return 0;
            }
            language.Name = entity.Name;
            language.Code = entity.Code;
            _unitOfWork.GetRepository<Language>().Update(language);
            try
            {
                return await _unitOfWork.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (await GetByIdAsync(id) != null)
                {
                    return 0;
                }
                else
                {
                    throw ex;
                }
            }

        }
    }
}
