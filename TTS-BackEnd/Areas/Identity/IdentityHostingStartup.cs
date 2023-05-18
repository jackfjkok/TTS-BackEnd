using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TTS_BackEnd.Areas.Identity.Data;

[assembly: HostingStartup(typeof(TTS_BackEnd.Areas.Identity.IdentityHostingStartup))]
namespace TTS_BackEnd.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<TTSBackEndDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("TTSBackEndDbContextConnection")));

                services.AddDefaultIdentity<IdentityUser>()
                    .AddEntityFrameworkStores<TTSBackEndDbContext>();
            });
        }
    }
}