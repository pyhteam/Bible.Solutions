using Bible.Database.Entities;
using Bible.DTOs.Queries;
using Bible.DTOs.Views;
using Bible.Service.Interfaces;
using Bible.Service.Services.BaseService;
using Microsoft.EntityFrameworkCore;

namespace Bible.Service.Services.SectionServices
{
    public class SectionSerive : ServiceBase<IUnitOfWork>, ISectionService
    {
        public SectionSerive(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<bool> CreateAsync(SectionQuery entity)
        {
            Section section = new Section()
            {
                Name = entity.Name,
            };
            _unitOfWork.GetRepository<Section>().Add(section);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task<int> DeleteAsync(int id)
        {
            if (id == 0)
            {
                return 0;
            }
            var section = _unitOfWork.GetRepository<Section>().Get(id);
            if (section == null)
            {
                return 0;
            }
            _unitOfWork.GetRepository<Section>().Delete(section);
            return await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<SectionView>> GetAllAsync()
        {
            var sections = await _unitOfWork.GetRepository<Section>().AsQueryable().Select(x => new SectionView()
            {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync();
            return sections;
        }

        public async Task<SectionView> GetByIdAsync(int id)
        {
            if (id == 0)
            {
                return null;
            }
            var section = _unitOfWork.GetRepository<Section>().Get(id);
            if (section == null)
            {
                return null;
            }
            return new SectionView()
            {
                Id = section.Id,
                Name = section.Name
            };
        }

        public async Task<int> UpdateAsync(SectionQuery entity, int id)
        {
            if (id == 0)
            {
                return 0;
            }
            var section = _unitOfWork.GetRepository<Section>().Get(id);
            if (section == null)
            {
                return 0;
            }
            section.Name = entity.Name;
            _unitOfWork.GetRepository<Section>().Update(section);
            return await _unitOfWork.SaveChangesAsync();
        }
    }
}
