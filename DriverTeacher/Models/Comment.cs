namespace DriverTeacher.Models
{
    /// <summary>
    /// Model of the user comment.
    /// </summary>
    public class Comment
    {
        /// <summary>
        /// Gets or sets comment ID in the database.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets comment owner's username in the application.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets comment's X coordinate.
        /// </summary>
        public string XCoord { get; set; }

        /// <summary>
        /// Gets or sets comment's Y coordinate.
        /// </summary>
        public string YCoord { get; set; }

        /// <summary>
        /// Gets or sets comment text.
        /// </summary>
        public string Text { get; set; }


    }
}