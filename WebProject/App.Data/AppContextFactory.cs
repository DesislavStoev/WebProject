using App.Web.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace App.Data
{
    public class AppContextFactory : IDesignTimeDbContextFactory<AppRContext>
    {
        public AppRContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var builder = new DbContextOptionsBuilder<AppRContext>();
            var connectonString = configuration.GetConnectionString("DefaultConnection");

            builder.UseSqlServer(connectonString);

            builder.ConfigureWarnings(w => w.Throw(RelationalEventId.QueryClientEvaluationWarning));

            return new AppRContext(builder.Options);
        }
    }
}
