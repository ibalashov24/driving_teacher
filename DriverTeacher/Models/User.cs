namespace DriverTeacher.Models
{
    /// <summary>
    /// Model of the application user.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets user ID in the database.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets user name in the application.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets user password.
        /// </summary>
        public string PasswordHash { get; set; }
    }
}