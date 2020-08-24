using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using SocialMedia.API.Domain.Identity;
using SocialMedia.API.Persistence.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SocialMedia.API.Application.Logic.Users.Query
{
    public class ForgetPasswordQueryHandler : IRequestHandler<ForgetPasswordQuery, string>
    {
        private readonly DataContext context;
        private readonly UserManager<AppUser> userManager;

        public ForgetPasswordQueryHandler(DataContext context, UserManager<AppUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }
        public async Task<string> Handle(ForgetPasswordQuery request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByEmailAsync(request.Email);
            if (user != null)
            {
                var token = await userManager.GeneratePasswordResetTokenAsync(user);
                //var encodedToken = Encoding.UTF8.GetBytes(token);
                //var validToken = WebEncoders.Base64UrlEncode(encodedToken);
                var url = $"https://localhost:5001/ResetPassword?email={request.Email}&token={token}";
                return url;
            }
            throw new NotImplementedException();
        }
    }
}
