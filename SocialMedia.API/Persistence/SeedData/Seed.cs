using Microsoft.AspNetCore.Identity;
using SocialMedia.API.Domain.Identity;
using SocialMedia.API.Persistence.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.API.Persistence.SeedData
{
    public class Seed
    {
        public static async Task SeedData(DataContext context, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (!userManager.Users.Any())
            {
                var listRole = new List<IdentityRole>()
                {
                    new IdentityRole()
                    {
                        Name ="Admin"
                    },
                    new IdentityRole()
                    {
                        Name = "User"
                    }
                };

                foreach(var role in listRole)
                {
                    await roleManager.CreateAsync(role);
                }

                var users = new List<AppUser>
                {
                    new AppUser
                    {
                        FirstName ="Bob",
                        LastName = "test",
                        UserName = "bob",
                        Email = "bob@test.com"
                    },
                    new AppUser
                    {

                        UserName = "6825531065",
                        FirstName = "Puthik",
                        LastName ="Ma"
                        
                    }
                };

                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "Pa$$w0rd");
                    if (user.UserName == "6825531065")
                    {
                        await userManager.AddToRoleAsync(user, "Admin");
                    }
                    if (user.UserName == "bob")
                    {
                        await userManager.AddToRoleAsync(user, "User");
                    }
              

                }
            }


        }
    }
}
