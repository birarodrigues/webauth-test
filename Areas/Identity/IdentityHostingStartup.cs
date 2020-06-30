using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using webapp_auth.Areas.Identity.Data;

[assembly: HostingStartup(typeof(webapp_auth.Areas.Identity.IdentityHostingStartup))]
namespace webapp_auth.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<IdentityAuth>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("IdentityAuthConnection")));

                services.AddDefaultIdentity<WebAuthUser>()
                    .AddDefaultUI()
                    .AddEntityFrameworkStores<IdentityAuth>();
            });
        }
    }
}