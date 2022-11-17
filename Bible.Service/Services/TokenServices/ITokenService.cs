using Bible.Database.Entities;

namespace Bible.Service.Services.TokenServices
{
    public interface ITokenService
    {
        Task<string> CreateToken(User user);
    }
}
