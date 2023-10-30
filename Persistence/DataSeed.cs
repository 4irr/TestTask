using Domain;
using Microsoft.AspNetCore.Identity;

namespace Persistence
{
    public class DataSeed
    {
        public static async Task SeedDataAsync(ApplicationContext context, UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var users = new List<AppUser>
                {
                    new AppUser
                    {
                        UserName = "user1",
                        DisplayName = "Bob"
                    },

                    new AppUser
                    {
                        UserName = "user2",
                        DisplayName = "Alice"
                    }
                };

                foreach (var user in users)
                    await userManager.CreateAsync(user, "password");
            }
        }
    }
}
