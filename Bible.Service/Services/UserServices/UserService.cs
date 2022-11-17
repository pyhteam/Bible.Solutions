using Bible.Database.Entities;
using Bible.DTOs.Queries;
using Bible.DTOs.Views;
using Bible.Service.Interfaces;
using Bible.Service.Services.BaseService;
using Bible.Service.Services.TokenServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Bible.Service.Services.UserServices
{
    public class UserService : ServiceBase<IUnitOfWork>, IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenService _tokenService;
        public UserService(IUnitOfWork unitOfWork, UserManager<User> userManager, SignInManager<User> signInManager, ITokenService tokenService) : base(unitOfWork)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task<bool> CreateAsync(UserQuery entity)
        {
            if (entity == null)
            {
                return false;
            }
            var user = new User()
            {
                FirtName = entity.FirtName,
                LastName = entity.LastName,
                Email = entity.Email,
                UserName = entity.Email.Split("@")[0].ToLower(),
                DateOfBirth = entity.DateOfBirth
            };
            var result = await _userManager.CreateAsync(user, entity.Password);
            if (!result.Succeeded)
            {
                return false;
            }
            var roleResult = await _userManager.AddToRoleAsync(user, entity.Role);
            if (!roleResult.Succeeded)
            {
                return false;
            }
            return false;
        }

        public async Task<int> DeleteAsync(int id)
        {
            if (id == 0)
            {
                return 0;
            }
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return 0;
            }
            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                return 0;
            }
            return id;
        }

        public async Task<IEnumerable<UserView>> GetAllAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            var userViews = users.Select(x => new UserView()
            {
                Id = x.Id,
                FirtName = x.FirtName,
                LastName = x.LastName,
                Email = x.Email,
                DateOfBirth = x.DateOfBirth,
                Username = x.UserName,
                Image = x.Image,
                Role = _userManager.GetRolesAsync(x).Result.FirstOrDefault(),
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt,
                LastActive = x.LastActive
            });
            return userViews;
        }

        public async Task<UserView> GetByIdAsync(int id)
        {
            if (id == 0)
            {
                return null;
            }
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return null;
            }
            var userView = new UserView()
            {
                Id = user.Id,
                FirtName = user.FirtName,
                LastName = user.LastName,
                Email = user.Email,
                DateOfBirth = user.DateOfBirth,
                Username = user.UserName,
                Image = user.Image,
                Role = _userManager.GetRolesAsync(user).Result.FirstOrDefault(),
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt,
                LastActive = user.LastActive
            };
            return userView;
        }

        public async Task<UserView> Login(LoginQuery entity)
        {
            if (entity == null)
            {
                return null;
            }
            if (entity.Username.Contains("@"))
            {
                // Login with email
                var user = await _userManager.FindByEmailAsync(entity.Username);
                if (user == null)
                {
                    return null;
                }
                var result = await _signInManager.CheckPasswordSignInAsync(user, entity.Password, false);
                if (!result.Succeeded)
                {
                    return null;
                }
                var userView = new UserView()
                {
                    Id = user.Id,
                    FirtName = user.FirtName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Token = await _tokenService.CreateToken(user),
                    DateOfBirth = user.DateOfBirth,
                    Username = user.UserName,
                    Image = user.Image,
                    Role = _userManager.GetRolesAsync(user).Result.FirstOrDefault(),
                    CreatedAt = user.CreatedAt,
                };
                return userView;
            }
            else
            {
                // Login with username
                var user = await _userManager.FindByNameAsync(entity.Username);
                if (user == null)
                {
                    return null;
                }
                var result = await _signInManager.CheckPasswordSignInAsync(user, entity.Password, false);
                if (!result.Succeeded)
                {
                    return null;
                }
                var userView = new UserView()
                {
                    Id = user.Id,
                    FirtName = user.FirtName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Token = await _tokenService.CreateToken(user),
                    DateOfBirth = user.DateOfBirth,
                    Username = user.UserName,
                    Image = user.Image,
                    Role = _userManager.GetRolesAsync(user).Result.FirstOrDefault(),
                    CreatedAt = user.CreatedAt,
                };
                return userView;
            }


        }

        public async Task<UserView> Register(RegisterQuery entity)
        {
            if (entity == null)
            {
                return null;
            }
            var user = new User()
            {
                FirtName = entity.FirtName,
                LastName = entity.LastName,
                Email = entity.Email,
                UserName = entity.Email.Split("@")[0].ToLower(),
                DateOfBirth = entity.DateOfBirth
            };
            var result = await _userManager.CreateAsync(user, entity.Password);
            if (!result.Succeeded)
            {
                return null;
            }
            var roleResult = await _userManager.AddToRoleAsync(user, "Member");
            if (!roleResult.Succeeded)
            {
                return null;
            }
            var userView = new UserView()
            {
                Id = user.Id,
                FirtName = user.FirtName,
                LastName = user.LastName,
                Email = user.Email,
                Token = await _tokenService.CreateToken(user),
                DateOfBirth = user.DateOfBirth,
                Username = user.UserName,
                Image = user.Image,
                Role = _userManager.GetRolesAsync(user).Result.FirstOrDefault(),
                CreatedAt = DateTime.Now
            };
            return userView;
        }

        public async Task<int> UpdateAsync(UserQuery entity, int id)
        {
            if (entity == null || id == 0)
            {
                return 0;
            }
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return 0;
            }
            user.FirtName = entity.FirtName;
            user.LastName = entity.LastName;
            user.Email = entity.Email;
            user.UserName = entity.Email.Split("@")[0].ToLower();
            user.DateOfBirth = entity.DateOfBirth;
            user.UpdatedAt = DateTime.Now;
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                return 0;
            }
            // update role if it is changed
            var role = _userManager.GetRolesAsync(user).Result.FirstOrDefault();
            if (role != entity.Role & string.IsNullOrEmpty(entity.Role))
            {
                var roleResult = await _userManager.RemoveFromRoleAsync(user, role);
                if (!roleResult.Succeeded)
                {
                    return 0;
                }
                roleResult = await _userManager.AddToRoleAsync(user, entity.Role);
                if (!roleResult.Succeeded)
                {
                    return 0;
                }
            }
            return id;
        }
    }
}
