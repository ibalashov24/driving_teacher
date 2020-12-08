using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using DriverTeacher.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Web;

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
        /// Gets current user's name.
        /// </summary>
        private string CurrentUsername => this.User.FindFirstValue(ClaimTypes.Name);

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
            // Retrieves current user's comments
            var comments = this.context
                .Comments
                .Where(comment => comment.Username == this.CurrentUsername)
                .ToList();

            return new JsonResult(JsonSerializer.Serialize(comments));
        }

        /// <summary>
        /// Handles new user command adding.
        /// </summary>
        /// <param name="dataJson">New comment data.</param>
        /// <returns>Handled comment.</returns>
        public IActionResult OnPostNewComment(string dataJson)
        {
            var (x, y, text) = JsonSerializer.Deserialize<(float, float, string)>(dataJson);
            var newComment = new Comment
            {
                Username = this.CurrentUsername,
                XCoord = x,
                YCoord = y,
                Text = HttpUtility.JavaScriptStringEncode(text)
            };

            this.context
                .Comments
                .Add(newComment);

            return new JsonResult(JsonSerializer.Serialize(newComment));
        }

        public void OnGet()
        {
        }
    }
}