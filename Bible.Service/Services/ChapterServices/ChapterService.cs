using Bible.Database.Entities;
using Bible.DTOs.Queries;
using Bible.DTOs.Views;
using Bible.Service.Interfaces;
using Bible.Service.Services.BaseService;
using Microsoft.EntityFrameworkCore;

namespace Bible.Service.Services.ChapterServices
{
    public class ChapterService : ServiceBase<IUnitOfWork>, IChapterService
    {
        public ChapterService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<bool> CreateAsync(ChapterQuery entity)
        {
            if (entity == null)
            {
                return false;
            }
            var chapter = new Chapter()
            {
                Name = entity.Name,
                Summary = entity.Summary,
            };
            _unitOfWork.GetRepository<Chapter>().Add(chapter);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task<int> DeleteAsync(int id)
        {
            if (id == 0)
            {
                return 0;
            }
            var chapter = _unitOfWork.GetRepository<Chapter>().Get(id);
            if (chapter == null)
            {
                return 0;
            }
            _unitOfWork.GetRepository<Chapter>().Delete(chapter);
            return await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<ChapterView>> GetAllAsync()
        {
            var chapters = await _unitOfWork.GetRepository<Chapter>().AsQueryable()
                .Select(x => new ChapterView()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Summary = x.Summary,
                }).ToListAsync();
            return chapters;
        }

        public async Task<ChapterView> GetByIdAsync(int id)
        {
            var chapter = await _unitOfWork.GetRepository<Chapter>().AsQueryable()
                 .Select(x => new ChapterView()
                 {
                     Id = x.Id,
                     Name = x.Name,
                     Summary = x.Summary,
                 }).FirstOrDefaultAsync(x => x.Id == id);
            return chapter;
        }

        public async Task<int> UpdateAsync(ChapterQuery entity, int id)
        {
            if (entity == null || id == 0)
            {
                return 0;
            }
            var chapter = _unitOfWork.GetRepository<Chapter>().Get(id);
            if (chapter == null)
            {
                return 0;
            }
            chapter.Name = entity.Name;
            chapter.Summary = entity.Summary;
            _unitOfWork.GetRepository<Chapter>().Update(chapter);
            return await _unitOfWork.SaveChangesAsync();
        }
    }
}
