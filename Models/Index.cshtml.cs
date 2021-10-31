using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Obi.Pages
{
    public class IndexModel : PageModel
    {
        public IConfigurationRoot Configuration { get; set; }

        public string ContentPath { get; set; }

        public IndexModel(IWebHostEnvironment environment)
        {
            ContentPath = environment.ContentRootPath;
            OnGet();
        }

        public void OnGet()
        {
            Configuration = new ConfigurationBuilder().SetBasePath(ContentPath).AddJsonFile("appsettings.json").Build();
        }
    }
}
