namespace DriverTeacher.Pages.Teacher
{
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.Extensions.Logging;

    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="PrivacyModel"/> class.
        /// </summary>
        /// <param name="logger">Logger for service events.</param>
        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            this.logger = logger;
        }
    }
}