using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SocialMedia.API.Domain.Identity;
using SocialMedia.API.Domain.Models;
using SocialMedia.API.Persistence.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

                var photo = new Photo
                {
                    Url = "https://res.cloudinary.com/pma-datingsite/image/upload/v1598122812/12055105_corfzl.jpg"

                };
                context.Photos.Add(photo);
                await context.SaveChangesAsync();
                var users = new List<AppUser>
                {
                    new AppUser
                    {
                        FirstName ="Bob",
                        LastName = "Josh",
                        UserName = "bob",
                        Email = "bob@test.com",
                        DisplayName ="Bob Josh",
                        PhotoId = photo.Id

                    },
                    new AppUser
                    {
                       
                        UserName = "6825531065",
                        FirstName = "Puthik",
                        LastName ="Ma",
                        Email="puthik.ma@gmail.com",
                        DisplayName="Puthik Ma",
                        PhotoId = photo.Id

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
                    
                    //var updateUser = await context.Users.Where(x => x.Id == user.Id).FirstOrDefaultAsync();
                    //updateUser.PhotoId = photo.Id;
                    //await context.SaveChangesAsync();

                }
            }


        }
    }
}
