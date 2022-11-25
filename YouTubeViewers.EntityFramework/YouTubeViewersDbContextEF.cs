using AdresbeheerMDBlayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeViewers.EFLayer
{
    public class YouTubeViewersDbContextEF : DbContext
    {
        public string connectionString;
        public YouTubeViewersDbContextEF(DbContextOptions options,  string connectionString) : base(options) {
            this.connectionString = connectionString;
        }

        public DbSet<YouTubeViewerEF> YouTubeViewers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
