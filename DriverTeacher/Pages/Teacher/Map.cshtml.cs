using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using DriverTeacher.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace DriverTeacher.Pages.Teacher
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.Extensions.Logging;

    [Authorize]
    public class MapModel : PageModel
    {
        // Comment database context
        private readonly ApplicationUserContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="Index"/> class.
        /// </summary>
        /// <param name="context">Application commentContext.</param>
        public MapModel(ApplicationUserContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Handles AJAX request for user comments.
        /// </summary>
        /// <returns>Serialized user comments.</returns>
        public IActionResult OnGetComments()
        {
            var userName = this.User.FindFirstValue(ClaimTypes.Name);

            // Retrieves current user's comments
            var comments = this.context
                .Comments
                .Where(comment => comment.Username == userName)
                .ToList();

            return new JsonResult(JsonSerializer.Serialize(comments));
        }

        public void OnGet()
        {
        }
    }
}