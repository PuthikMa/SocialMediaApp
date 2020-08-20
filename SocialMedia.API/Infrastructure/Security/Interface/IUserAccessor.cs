using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.API.Infrastructure.Security.Interface
{
    public interface IUserAccessor
    {
        string GetCurrentUser();
    }
}
