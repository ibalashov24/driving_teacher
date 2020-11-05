namespace DriverTeacher.Pages
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using DriverTeacher.Models;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.Extensions.Configuration;

    public class Index : PageModel
    {
        private readonly IConfiguration configuration;

        public Index(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [BindProperty]
        public string ReturnUrl { get; set; }

        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string Message { get; set; }

        public async Task<IActionResult> OnPost()
        {
            var user = this.configuration.GetSection("SiteUser").Get<User>();

            if (this.Username == user.Username && this.Password == user.Password)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, this.Username)
                };
                var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await this.HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimIdentity));

                this.Message = "Again";
                return this.RedirectToPage("/Teacher/Map");
            }

            this.Message = "Invalid login information";
            return this.Page();
        }
    }
}