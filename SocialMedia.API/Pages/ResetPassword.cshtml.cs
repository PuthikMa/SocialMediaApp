using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SocialMedia.API.Pages
{
    public class ResetPasswordModel : PageModel
    {
        public void OnGet(HttpClient httpClient)
        {
        }
    }
}
