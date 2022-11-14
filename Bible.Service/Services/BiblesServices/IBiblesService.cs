using Bible.DTOs.Queries;
using Bible.DTOs.Views;
using Bible.Service.Services.BaseService;

namespace Bible.Service.Services.BiblesServices
{
    public interface IBiblesService : IBaseService<BiblesQuery, BiblesView>
    {
    }
}
