using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Obi.Areas.Identity.Data;
using Obi.Data;

[assembly: HostingStartup(typeof(Obi.Areas.Identity.IdentityHostingStartup))]
namespace Obi.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<ObiContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("ObiContextConnection")));

                services.AddDefaultIdentity<ObiUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<ObiContext>();
            });
        }
    }
}