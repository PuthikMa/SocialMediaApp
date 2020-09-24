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
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

namespace SocialMedia.API.Application.Logic.Users.Query
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, User>
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly IJWTGenerator jWTGenerator;
        private readonly DataContext context;

        public LoginQueryHandler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IJWTGenerator jWTGenerator, DataContext context)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.jWTGenerator = jWTGenerator;
            this.context = context;
        }
        public async Task<User> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByNameAsync(request.UserName);
            if(user == null)
            {
                user = await userManager.FindByEmailAsync(request.UserName);
            }
            
            if(user != null)
            {
                var result = await signInManager.CheckPasswordSignInAsync(user, request.Password, false);
                if (result.Succeeded)
                {
                    var photo = await context.Photos.Where(x => x.Id == user.PhotoId).FirstOrDefaultAsync();
                    return new User
                    {
                        DisplayName = user.DisplayName,
                        Token = await jWTGenerator.CreateToken(user),
                        Username = user.UserName,
                        ProfileImage = photo.Url
                
                    };
                }
            }

            throw new ArgumentNullException();
        
        }
    }
}
