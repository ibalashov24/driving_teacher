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

        /// <summary>
        /// Initializes a new instance of the <see cref="Index"/> class.
        /// </summary>
        /// <param name="configuration">Application configuration.</param>
        public Index(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        /// <summary>
        /// Gets or sets username of the user being authenticated.
        /// </summary>
        [BindProperty]
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets password of the user being authenticated.
        /// </summary>
        [BindProperty]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets status message for the user.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Handles user credentials form.
        /// </summary>
        /// <returns>Resulting page after authentication.</returns>
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

                return this.RedirectToPage("/Teacher/Map");
            }

            this.Message = "Invalid login information";
            return this.Page();
        }
    }
}