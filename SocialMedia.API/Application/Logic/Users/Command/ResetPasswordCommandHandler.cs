using MediatR;
using Microsoft.AspNetCore.Identity;
using SocialMedia.API.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SocialMedia.API.Application.Logic.Users.Command
{
    public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand>
    {
        private readonly UserManager<AppUser> userManager;

        public ResetPasswordCommandHandler(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }
        public async Task<Unit> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByEmailAsync(request.ResetPassword.Email);

            if(user != null)
            {
                if(request.ResetPassword.NewPassword == request.ResetPassword.ConfirmPassword)
                {
                    var result = await userManager.ResetPasswordAsync(user, request.ResetPassword.Token, request.ResetPassword.NewPassword);
                    if (result.Succeeded)
                    {
                        return Unit.Value;
                    }
                }
            }
            throw new NotImplementedException();
        }
    }
}
