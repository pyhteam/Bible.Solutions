using Bible.Database.Entities;
using Bible.DTOs.Queries;
using Bible.DTOs.Views;
using Bible.Service.Interfaces;
using Bible.Service.Services.BaseService;
using Microsoft.EntityFrameworkCore;

namespace Bible.Service.Services.BookServices
{
    public class BookService : ServiceBase<IUnitOfWork>, IBookService
    {
        public BookService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<bool> CreateAsync(BookQuery entity)
        {
            if (entity == null)
            {
                return false;
            }
            Book book = new Book()
            {
                Name = entity.Name,
                CodeBook = entity.CodeBook,
                Introduce = entity.Introduce,
                LanguageId = entity.LanguageId,
                SectionId = entity.SectionId
            };
            _unitOfWork.GetRepository<Book>().Add(book);
            return await _unitOfWork.SaveChangesAsync() > 0;


        }

        public async Task<int> DeleteAsync(int id)
        {
            if (id == 0)
            {
                return 0;
            }
            var book = _unitOfWork.GetRepository<Book>().Get(id);
            if (book == null)
            {
                return 0;
            }
            _unitOfWork.GetRepository<Book>().Delete(book);
            return await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<BookView>> GetAllAsync()
        {
            var books = await _unitOfWork.GetRepository<Book>().AsQueryable()
             .Include(x => x.Language)
             .Include(x => x.Section)
                .Select(x => new BookView()
                {
                    Id = x.Id,
                    Name = x.Name,
                    CodeBook = x.CodeBook,
                    Introduce = x.Introduce,
                    LanguageId = x.LanguageId,
                    LanguageCode = x.Language.Code,
                    LanguageName = x.Language.Name,
                    SectionId = x.SectionId,
                    SectionName = x.Section.Name
                }).ToListAsync();
            return books;
        }

        public async Task<BookView> GetByIdAsync(int id)
        {
            if (id == 0)
            {
                return null;
            }
            var book = await _unitOfWork.GetRepository<Book>().AsQueryable()
             .Include(x => x.Language)
             .Include(x => x.Section)
             .Select(x => new BookView()
             {
                 Id = x.Id,
                 Name = x.Name,
                 CodeBook = x.CodeBook,
                 Introduce = x.Introduce,
                 LanguageId = x.LanguageId,
                 LanguageCode = x.Language.Code,
                 LanguageName = x.Language.Name,
                 SectionId = x.SectionId,
                 SectionName = x.Section.Name
             }).FirstOrDefaultAsync(x => x.Equals(id));
            return book;
        }

        public async Task<int> UpdateAsync(BookQuery entity, int id)
        {
            if (entity == null || id == 0)
            {
                return null;
            }
            var book = _unitOfWork.GetRepository<Book>().Get(id);
            if (book == null)
            {
                return null;
            }
            book.Name = entity.Name;
            book.CodeBook = entity.CodeBook;
            book.Introduce = entity.Introduce;
            book.LanguageId = entity.LanguageId;
            book.SectionId = entity.SectionId;
            _unitOfWork.GetRepository<Book>().Update(book);
            return await _unitOfWork.SaveChangesAsync();
        }
    }
}
