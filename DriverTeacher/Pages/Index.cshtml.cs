using System.Text;

namespace DriverTeacher.Pages
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Security.Claims;
    using System.Security.Cryptography;
    using System.Security.Policy;
    using System.Threading.Tasks;
    using DriverTeacher.Models;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;

    public class Index : PageModel
    {
        private readonly ApplicationDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="Index"/> class.
        /// </summary>
        /// <param name="context">Application context.</param>
        public Index(ApplicationDbContext context)
        {
            this.context = context;
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
        /// Gets status message for the user.
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// Calculatex hexadecimal hash string from given string.
        /// </summary>
        /// <param name="source">Source string.</param>
        /// <returns>Hexadecimal hash string.</returns>
        private static string CalcStringSha256(string source)
        {
            var sha256 = SHA256.Create();
            var rawHash = sha256.ComputeHash(Encoding.UTF8.GetBytes(source));

            var stringBuilder = new StringBuilder();
            foreach (var t in rawHash)
            {
                stringBuilder.Append(t.ToString("x2"));
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Handles user credentials form.
        /// </summary>
        /// <returns>Resulting page after authentication.</returns>
        public async Task<IActionResult> OnPost()
        {
            var passwordHash = CalcStringSha256(this.Password);

            if (this.context.Users
                .Any(a => a.Username == this.Username && a.PasswordHash == passwordHash))
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