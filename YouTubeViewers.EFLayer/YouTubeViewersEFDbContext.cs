using YouTubeViewers.EFLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeViewers.EFLayer.Repositories
{
    public class YouTubeViewersEFDbContext : DbContext
    {
        public string connectionString;
        public YouTubeViewersEFDbContext(string connectionString) {

            //DbContextOptions options,
            // : base(options)

            this.connectionString = connectionString;
        }

        public DbSet<YouTubeViewerEF> YouTubeViewers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
