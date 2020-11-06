namespace DriverTeacher.Pages.Teacher
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.Extensions.Logging;

    [Authorize]
    public class MapModel : PageModel
    {
        /// <summary>
        /// Logger for service events.
        /// </summary>
        private readonly ILogger<MapModel> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="MapModel"/> class.
        /// </summary>
        /// <param name="logger">Logger for service events.</param>
        public MapModel(ILogger<MapModel> logger)
            {
            this.logger = logger;
        }
    }
}