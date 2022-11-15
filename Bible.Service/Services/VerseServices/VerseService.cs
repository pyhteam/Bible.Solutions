using Bible.Database.Entities;
using Bible.DTOs.Queries;
using Bible.DTOs.Views;
using Bible.Service.Interfaces;
using Bible.Service.Services.BaseService;
using Microsoft.EntityFrameworkCore;

namespace Bible.Service.Services.VerseServices
{
    public class VerseService : ServiceBase<IUnitOfWork>, IVerseService
    {
        public VerseService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<bool> CreateAsync(VerseQuery entity)
        {
            if (entity == null)
            {
                return false;
            }
            var verse = new Verse()
            {
                Content = entity.Content,
                SectionId = entity.SectionId,
                Number = entity.Number
            };
            _unitOfWork.GetRepository<Verse>().Add(verse);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task<int> DeleteAsync(int id)
        {
            if (id == 0)
            {
                return 0;
            }
            var verse = _unitOfWork.GetRepository<Verse>().Get(id);
            if (verse == null)
            {
                return 0;
            }
            _unitOfWork.GetRepository<Verse>().Delete(verse);
            return await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<VerserView>> GetAllAsync()
        {
            var verses = await _unitOfWork.GetRepository<Verse>().AsQueryable()
                .Include(x => x.Section)
                .Select(x => new VerserView()
                {
                    Id = x.Id,
                    Content = x.Content,
                    Number = x.Number,
                    SectionId = x.SectionId,
                    SectionName = x.Section.Name,
                    AudioVerses = x.AudioVerses.Select(y => new AudioVerseView()
                    {
                        Id = y.Id,
                        Name = y.Name,
                        LinkAudio = y.LinkAudio,
                        Vocal = y.Vocal,
                        CreatedBy = y.CreatedBy,
                        UpdatedBy = y.UpdatedBy,
                        IsActive = y.IsActive,
                        CreatedAt = y.CreatedAt,
                        UpdatedAt = y.UpdateAt,
                    }).ToList(),
                }).ToListAsync();
            return verses;
        }

        public async Task<VerserView> GetByIdAsync(int id)
        {
            if (id == 0)
            {
                return null;
            }
            var verse = await _unitOfWork.GetRepository<Verse>().AsQueryable()
                .Include(x => x.Section)
                .Select(x => new VerserView()
                {
                    Id = x.Id,
                    Number = x.Number,
                    Content = x.Content,
                    SectionId = x.SectionId,
                    SectionName = x.Section.Name,
                    AudioVerses = x.AudioVerses.Select(y => new AudioVerseView()
                    {
                        Id = y.Id,
                        Name = y.Name,
                        LinkAudio = y.LinkAudio,
                        Vocal = y.Vocal,
                        CreatedBy = y.CreatedBy,
                        UpdatedBy = y.UpdatedBy,
                        IsActive = y.IsActive,
                        CreatedAt = y.CreatedAt,
                        UpdatedAt = y.UpdateAt,
                    }).ToList(),
                }).FirstOrDefaultAsync(x => x.Equals(id));
            return verse;
        }

        public async Task<int> UpdateAsync(VerseQuery entity, int id)
        {
            if (entity == null || id == 0)
            {
                return 0;
            }
            var verse = _unitOfWork.GetRepository<Verse>().Get(id);
            if (verse == null)
            {
                return 0;
            }
            verse.Content = entity.Content;
            verse.SectionId = entity.SectionId;
            verse.Number = entity.Number;
            _unitOfWork.GetRepository<Verse>().Update(verse);
            return await _unitOfWork.SaveChangesAsync();
        }
    }
}
