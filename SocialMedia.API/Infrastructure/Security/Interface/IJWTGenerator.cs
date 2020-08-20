using SocialMedia.API.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.API.Infrastructure.Security.Interface
{
    public interface IJWTGenerator
    {
        Task<string> CreateToken(AppUser user);
    }

}
