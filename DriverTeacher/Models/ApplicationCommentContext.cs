using DriverTeacher.Pages.Teacher;

namespace DriverTeacher.Models
{
    using Microsoft.EntityFrameworkCore;

    public sealed class ApplicationCommentContext : DbContext
    {
        /// <summary>
        /// Gets or sets application users.
        /// </summary>
        public DbSet<Comment> Comments { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationCommentContext"/> class.
        /// </summary>
        /// <param name="options">DB options.</param>
        public ApplicationCommentContext(DbContextOptions<ApplicationUserContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }

    }
}