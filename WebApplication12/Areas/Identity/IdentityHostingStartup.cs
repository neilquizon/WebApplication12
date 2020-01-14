using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApplication12.Areas.Identity.Data;
using WebApplication12.Models;

[assembly: HostingStartup(typeof(WebApplication12.Areas.Identity.IdentityHostingStartup))]
namespace WebApplication12.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<WebApplication12Context>(options =>
                    options.UseSqlite(
                        context.Configuration.GetConnectionString("WebApplication12ContextConnection")));

                services.AddDefaultIdentity<WebApplication12User>()
                    .AddEntityFrameworkStores<WebApplication12Context>();
            });
        }
    }
}