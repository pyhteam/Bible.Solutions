using Bible.Database.Entities;
using Bible.DTOs.Queries;
using Bible.DTOs.Views;
using Bible.Service.Interfaces;
using Bible.Service.Services.BaseService;
using Microsoft.EntityFrameworkCore;

namespace Bible.Service.Services.AudioVerseServices
{
    public class AudioVerseService : ServiceBase<IUnitOfWork>, IAudioVerseService
    {
        public AudioVerseService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<bool> CreateAsync(AudioVerseQuery entity)
        {
            if (entity == null)
            {
                return false;
            }
            var audioVerse = new AudioVerse()
            {
                LinkAudio = entity.LinkAudio,
                Name = entity.Name,
                Vocal = entity.Vocal,
                VerseId = entity.VerseId,
            };
            _unitOfWork.GetRepository<AudioVerse>().Add(audioVerse);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task<int> DeleteAsync(int id)
        {
            if (id == 0)
            {
                return 0;
            }
            var audioVerse = _unitOfWork.GetRepository<AudioVerse>().Get(id);
            if (audioVerse == null)
            {
                return 0;
            }
            _unitOfWork.GetRepository<AudioVerse>().Delete(audioVerse);
            return await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<AudioVerseView>> GetAllAsync()
        {
            var audioVerse = await _unitOfWork.GetRepository<AudioVerse>().AsQueryable()
                .Select(x => new AudioVerseView()
                {
                    Id = x.Id,
                    LinkAudio = x.LinkAudio,
                    Name = x.Name,
                    Vocal = x.Vocal,
                    VerseId = x.VerseId,
                    CreatedAt = x.CreatedAt
                }).ToListAsync();
            return audioVerse;
        }

        public async Task<AudioVerseView> GetByIdAsync(int id)
        {
            if (id == 0)
            {
                return null;
            }
            var audioVerse = await _unitOfWork.GetRepository<AudioVerse>().AsQueryable()
                .Include(x => x.Verse)
                .Select(x => new AudioVerseView()
                {
                    Id = x.Id,
                    LinkAudio = x.LinkAudio,
                    Name = x.Name,
                    Vocal = x.Vocal,
                    VerseId = x.VerseId,
                    CreatedAt = x.CreatedAt,

                }).FirstOrDefaultAsync(x => x.Id.Equals(id));
            return audioVerse;
        }

        public async Task<int> UpdateAsync(AudioVerseQuery entity, int id)
        {
            if (entity == null || id == 0)
            {
                return 0;
            }
            var audioVerse = _unitOfWork.GetRepository<AudioVerse>().Get(id);
            if (audioVerse == null)
            {
                return 0;
            }
            audioVerse.LinkAudio = entity.LinkAudio;
            audioVerse.Name = entity.Name;
            audioVerse.Vocal = entity.Vocal;
            audioVerse.VerseId = entity.VerseId;
            _unitOfWork.GetRepository<AudioVerse>().Update(audioVerse);
            return await _unitOfWork.SaveChangesAsync();
        }
    }
}
