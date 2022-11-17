using Bible.Database.Entities;
using Microsoft.AspNetCore.Identity;

namespace Bible.Database.Data
{
    public class Seed
    {
        public async static Task<int> SeedUser(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            if (userManager.Users.Any())
            {
                return 0;
            }

            var users = new List<User>()
            {
                new User()
                {
                    FirtName = "System",
                    LastName = "Admin",
                    UserName = "admin",
                    Email = "admin@hmz.bibles.com",
                },
                new User()
                {
                    FirtName = "Mod",
                    LastName = "System",
                    UserName = "mod",
                    Email = "mod.system@hmz.bibles.com",
                },
                new User()
                {
                    FirtName = "MS",
                    LastName = "Sen",
                    UserName = "senms",
                    Email = "senms@hmz.bibles.com",
                }
            };

            var roles = new List<Role>
            {
                new Role(){ Name="Member"},
                new Role(){ Name="Admin"},
                new Role(){ Name="Mod"},
            };
            foreach (var role in roles)
            {
                await roleManager.CreateAsync(role);
            }

            foreach (var user in users)
            {
                user.UserName = user.UserName.ToLower();
                await userManager.CreateAsync(user, "Abc12345@");
                if (user.UserName.Equals("admin"))
                {
                    await userManager.AddToRoleAsync(user, "Admin");
                    await userManager.AddToRoleAsync(user, "Mod");
                }
                else if (user.UserName.Equals("mod"))
                {
                    await userManager.AddToRoleAsync(user, "Mod");
                }
                else
                {
                    await userManager.AddToRoleAsync(user, "Member");
                }

            };

            return users.Count;
        }
    }
}
