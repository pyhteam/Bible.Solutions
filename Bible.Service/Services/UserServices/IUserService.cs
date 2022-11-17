using Bible.DTOs.Queries;
using Bible.DTOs.Views;
using Bible.Service.Services.BaseService;

namespace Bible.Service.Services.UserServices
{
    public interface IUserService : IBaseService<UserQuery, UserView>
    {
        Task<UserView> Register(RegisterQuery entity);
        Task<UserView> Login(LoginQuery entity);
    }
}
