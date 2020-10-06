using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace DriverTeacher.Pages
{
    public class IndexModel : PageModel
    {
        public string UserName { get; set; }

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet(string username)
        {
            var lowerUsername = username.ToLower();
            if (lowerUsername == string.Empty)
            {
                return;
            }

            UserName = lowerUsername;
        }
    }
}