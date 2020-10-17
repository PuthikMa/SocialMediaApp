using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SocialMedia.API.Domain.Identity;
using SocialMedia.API.Domain.Models;
using SocialMedia.API.Infrastructure.Security.Interface;
using SocialMedia.API.Persistence.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SocialMedia.API.Application.Logic.Users.Command
{
    public class UserRegisterCommandHandler : IRequestHandler<UserRegisterCommand, User>
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly IJWTGenerator jWTGenerator;
        private readonly DataContext dbContext;


        public UserRegisterCommandHandler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IJWTGenerator jWTGenerator, DataContext dbContext)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.jWTGenerator = jWTGenerator;
            this.dbContext = dbContext;

        }
        public async Task<User> Handle(UserRegisterCommand request, CancellationToken cancellationToken)
        {
            var userExist = await dbContext.Users.Where(x => x.UserName == request.UserName).AnyAsync();
            var defaultPhotoId = await dbContext.Photos.Select(x=>x.Id).FirstOrDefaultAsync();
            if (userExist)
            {
                throw new Exception();
            }
            else
            {
                var user = new AppUser
                {
                    DisplayName = $"{request.FirstName} {request.LastName}",
                    UserName = request.UserName,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    PhotoId = defaultPhotoId

                };

                

                var result = await userManager.CreateAsync(user, request.Password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "User");
                    return new User
                    {
                        DisplayName = user.DisplayName,
                        Token = await jWTGenerator.CreateToken(user),
                        ProfileImage = null
                    };
                }
            }

            throw new ArgumentNullException();

        }
    }
}
