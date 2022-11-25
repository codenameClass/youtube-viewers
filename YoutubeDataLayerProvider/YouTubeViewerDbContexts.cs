using YouTubeViewers.EFLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeViewers.Domain.Interfaces;
using YouTubeViewers.EFLayer;

namespace YouTubeViewers.DataLayerProvider
{
    public class YouTubeViewerDbContexts
    {
        public DbContext DbContext { get; }

        public YouTubeViewerDbContexts(string connectionstring,RepositoryType repositoryType)
        {
            try
            {
                switch (repositoryType)
                {
                    case RepositoryType.MDB:
                        //Todo: momenteel ingevuld zodat je steeds iets terug geeft
                        DbContext = new YouTubeViewersDbContextEF(null, connectionstring);
                        break;
                    case RepositoryType.EFCore:
                        DbContext = new YouTubeViewersDbContextEF(null, connectionstring);
                        break;
                    default: throw new YouTubeViewerDbContextFactoryException("GeefContext");
                }
            }
            catch (Exception ex)
            {
                throw new YouTubeViewerDbContextFactoryException("GeefRepository", ex);

            }
        }
    }
}
