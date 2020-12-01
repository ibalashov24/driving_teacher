using System;
using System.Collections.Generic;
using System.Linq;
using DriverTeacher.Models;
using Microsoft.AspNetCore.Mvc;

namespace DriverTeacher.Pages.Teacher
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.Extensions.Logging;

    [Authorize]
    public class MapModel : PageModel
    {
        // Comment database context
        private readonly ApplicationCommentContext commentContext;

        // Comment field
        [BindProperty]
        public List<Comment> UserComments { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Index"/> class.
        /// </summary>
        /// <param name="commentContext">Application commentContext.</param>
        public MapModel(ApplicationCommentContext commentContext)
        {
            this.commentContext = commentContext;
        }

        public void OnGet()
        {
            // Retrieves current user's comments
            this.UserComments = this.commentContext
                .Comments
                .Where(comment => comment.Username == this.HttpContext.User.ToString())
                .ToList();
        }
    }
}