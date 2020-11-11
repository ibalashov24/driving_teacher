namespace DriverTeacher.Models
{
    using Microsoft.EntityFrameworkCore;

    public sealed class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// Gets or sets application users.
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
        /// </summary>
        /// <param name="options">DB options.</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }

    }
}