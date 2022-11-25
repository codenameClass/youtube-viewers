using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeViewers.DataLayerProvider
{
    public static class YouTubeViewerDataLayerFactory
    {
        public static YouTubeViewerRepositories GeefRepositories(string connectionstring, RepositoryType repositoryType)
        {
            return new YouTubeViewerRepositories(connectionstring, repositoryType);
        }

        public static YouTubeViewerDbContexts GeefContext(string connectionstring,RepositoryType repositoryType)
        {
            return new YouTubeViewerDbContexts(connectionstring, repositoryType);
        }
    }
}
