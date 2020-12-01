namespace DriverTeacher.Models
{
    using Microsoft.EntityFrameworkCore;

    public sealed class ApplicationUserContext : DbContext
    {
        /// <summary>
        /// Gets or sets application users.
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationUserContext"/> class.
        /// </summary>
        /// <param name="options">DB options.</param>
        public ApplicationUserContext(DbContextOptions<ApplicationUserContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }

    }
}