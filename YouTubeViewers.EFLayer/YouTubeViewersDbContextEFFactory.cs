using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeViewers.EFLayer.Repositories
{
    public class YouTubeViewersDbContextEFFactory
    {
        private readonly DbContextOptions _options;
        private readonly string _connectionstring;

        public YouTubeViewersDbContextEFFactory(DbContextOptions options, string connectionstring)
        {
            _options = options;
            _connectionstring = connectionstring;
            
        }

        public YouTubeViewersDbContextEF Create()
        {
            return new YouTubeViewersDbContextEF(_options, _connectionstring);
        }
    }
}
