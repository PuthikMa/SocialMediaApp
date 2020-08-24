using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.API.Application.Logic.Users.Query
{
    public class ForgetPasswordQuery : IRequest <string>
    {
        public string Email { get; set; }
    }
}
