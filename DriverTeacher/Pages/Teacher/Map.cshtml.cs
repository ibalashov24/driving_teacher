using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace DriverTeacher.Pages.Teacher
{
    [Authorize]
    public class MapModel : PageModel
    {
        private readonly ILogger<MapModel> logger;

        public MapModel(ILogger<MapModel> logger)
            {
            this.logger = logger;
        }
    }
}