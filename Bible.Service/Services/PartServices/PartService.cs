using Bible.Database.Entities;
using Bible.DTOs.Queries;
using Bible.DTOs.Views;
using Bible.Service.Interfaces;
using Bible.Service.Services.BaseService;
using Microsoft.EntityFrameworkCore;

namespace Bible.Service.Services.PartServices
{
    public class PartService : ServiceBase<IUnitOfWork>, IPartService
    {
        public PartService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<bool> CreateAsync(PartQuery entity)
        {
            if (entity == null)
            {
                return false;
            }
            if (entity.PartParentId == 0)
            {
                entity.PartParentId = null;
            }
            var part = new Part()
            {
                Name = entity.Name,
                PartParentId = entity.PartParentId,
                BiblesId = entity.BiblesId
            };
            _unitOfWork.GetRepository<Part>().Add(part);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task<int> DeleteAsync(int id)
        {
            if (id == 0)
            {
                return 0;
            }
            var part = _unitOfWork.GetRepository<Part>().Get(id);
            if (part == null)
            {
                return 0;
            }
            _unitOfWork.GetRepository<Part>().Delete(part);
            return await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<PartView>> GetAllAsync()
        {
            var parts = await _unitOfWork.GetRepository<Part>().AsQueryable()
                .Include(x => x.Bibles)
                .Include(x => x.PartParent)
                .Select(x => new PartView()
                {
                    Id = x.Id,
                    Name = x.Name,
                    PartParentId = x.PartParentId ?? 0,
                    PartParentName = x.PartParent.Name,
                    BiblesId = x.BiblesId,
                    BiblesName = x.Bibles.Name
                }).ToListAsync();
            return parts;
        }

        public async Task<PartView> GetByIdAsync(int id)
        {
            if (id == 0)
            {
                return null;
            }
            var part = await _unitOfWork.GetRepository<Part>().AsQueryable()
                .Include(x => x.Bibles)
                .Include(x => x.PartParent).ThenInclude(a => a.PartParent)
                .Select(x => new PartView()
                {
                    Id = x.Id,
                    Name = x.Name,
                    PartParentId = x.PartParentId ?? 0,
                    PartParentName = x.PartParent.Name,
                    BiblesId = x.BiblesId,
                    BiblesName = x.Bibles.Name,
                    ListChildPart = x.ChildParts.Select(a => new PartView()
                    {
                        Id = a.Id,
                        Name = a.Name,
                        PartParentId = a.PartParentId ?? 0,
                        PartParentName = a.PartParent.Name,
                        BiblesId = a.BiblesId,
                        BiblesName = a.Bibles.Name
                    }).ToList(),
                    Books = x.Books.Select(a => new BookView()
                    {
                        Id = a.Id,
                        Name = a.Name,
                        PartId = a.PartId,
                        PartName = a.Part.Name,
                    }).ToList()

                }).FirstOrDefaultAsync(x => x.Id == id);
            return part;
        }

        public async Task<int> UpdateAsync(PartQuery entity, int id)
        {
            if (entity == null || id == 0)
            {
                return 0;
            }
            var part = _unitOfWork.GetRepository<Part>().Get(id);
            if (part == null)
            {
                return 0;
            }
            if (entity.PartParentId == 0)
            {
                entity.PartParentId = null;
            }
            part.Name = entity.Name;
            part.PartParentId = entity.PartParentId;
            part.BiblesId = entity.BiblesId;
            _unitOfWork.GetRepository<Part>().Update(part);
            return await _unitOfWork.SaveChangesAsync();
        }
    }
}
