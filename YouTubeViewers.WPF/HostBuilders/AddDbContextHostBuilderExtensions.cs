using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeViewers.DataLayerProvider;
using YouTubeViewers.EFLayer;
using YouTubeViewers.EFLayer.Repositories;

namespace YouTubeViewers.WPF.HostBuilders
{
    public static class AddDbContextHostBuilderExtensions
    {
        private static RepositoryType type;
        public static IHostBuilder AddDbContext(this IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureServices((context, services) =>
            {
                services.AddDbContext<DbContext>();
                string datalayer = System.Configuration.ConfigurationManager.AppSettings["DataLayer"];

                type = datalayer == "EFC" ? RepositoryType.EFCore : RepositoryType.MDB;
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings[datalayer].ConnectionString;
                if (type == RepositoryType.EFCore)
                {
                    services.AddSingleton<DbContextOptions>(new DbContextOptionsBuilder().UseSqlServer(connectionString).Options);
                    services.AddSingleton<string>(connectionString);
                    services.AddSingleton<YouTubeViewersDbContextEFFactory>();
                }
                else
                {
                    // ...
                }
            });
                
            return hostBuilder;
        }
    }
}
