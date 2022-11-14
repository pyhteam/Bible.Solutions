using Bible.DTOs.Queries;
using Bible.DTOs.Views;
using Bible.Service.Interfaces;
using Bible.Service.Services.BaseService;

namespace Bible.Service.Services.BookServices
{
    public interface IBookService : IBaseService<BookQuery, BookView>
    {

    }
}
