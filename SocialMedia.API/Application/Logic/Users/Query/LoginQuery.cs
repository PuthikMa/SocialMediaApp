using MediatR;
using SocialMedia.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.API.Application.Logic.Users.Query
{
    public class LoginQuery : IRequest<User>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
