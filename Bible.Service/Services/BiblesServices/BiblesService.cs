using Bible.Database.Entities;
using Bible.DTOs.Queries;
using Bible.DTOs.Views;
using Bible.Service.Interfaces;
using Bible.Service.Services.BaseService;
using Microsoft.EntityFrameworkCore;

namespace Bible.Service.Services.BiblesServices
{
    public class BiblesService : ServiceBase<IUnitOfWork>, IBiblesService
    {
        public BiblesService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<bool> CreateAsync(BiblesQuery entity)
        {
            if (entity == null)
            {
                return false;
            }
            var bible = new Bibles()
            {
                Code = entity.Code,
                Name = entity.Name,
                LanguageId = entity.LanguageId,
            };
            _unitOfWork.GetRepository<Bibles>().Add(bible);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task<int> DeleteAsync(int id)
        {
            if (id == 0)
            {
                return 0;
            }
            var bible = _unitOfWork.GetRepository<Bibles>().Get(id);
            if (bible == null)
            {
                return 0;
            }
            _unitOfWork.GetRepository<Bibles>().Delete(bible);
            return await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<BiblesView>> GetAllAsync()
        {
            var bibles = await _unitOfWork.GetRepository<Bibles>().AsQueryable()
                .Include(x => x.Language)
                .Select(x => new BiblesView()
                {
                    Id = x.Id,
                    Code = x.Code,
                    Name = x.Name,
                    LanguageId = x.LanguageId,
                    LanguageCode = x.Language.Code,
                    LanguageName = x.Language.Name,
                }).ToListAsync();
            return bibles;
        }

        public async Task<BiblesView> GetByIdAsync(int id)
        {
            if (id == 0)
            {
                return null;
            }
            var bible = await _unitOfWork.GetRepository<Bibles>().AsQueryable()
                .Include(x => x.Language)
                .Select(x => new BiblesView()
                {
                    Id = x.Id,
                    Code = x.Code,
                    Name = x.Name,
                    LanguageId = x.LanguageId,
                    LanguageCode = x.Language.Code,
                    LanguageName = x.Language.Name,

                }).FirstOrDefaultAsync(x => x.Id.Equals(id));
            return bible;
        }

        public async Task<int> UpdateAsync(BiblesQuery entity, int id)
        {
            if (entity == null || id == 0)
            {
                return 0;
            }
            var bible = _unitOfWork.GetRepository<Bibles>().Get(id);
            if (bible == null)
            {
                return 0;
            }
            bible.Code = entity.Code;
            bible.Name = entity.Name;
            bible.LanguageId = entity.LanguageId;
            _unitOfWork.GetRepository<Bibles>().Update(bible);
            return await _unitOfWork.SaveChangesAsync();
        }
    }
}
