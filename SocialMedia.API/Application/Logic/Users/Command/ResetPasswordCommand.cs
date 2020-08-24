using MediatR;
using SocialMedia.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.API.Application.Logic.Users.Command
{
    public class ResetPasswordCommand : IRequest
    {
        public ResetPassword  ResetPassword { get; set; }
    }
}
