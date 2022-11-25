using YouTubeViewers.EFLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeViewers.Domain.Interfaces;
namespace YouTubeViewers.DataLayerProvider
{
    public class YouTubeViewerRepositories
    {
        public IYouTubeViewerRepository IYoutubeViewerRepository { get; }

        public YouTubeViewerRepositories(string connectionString, RepositoryType repositoryType)
        {
            try
            {
                switch (repositoryType)
                {
                    case RepositoryType.MDB:
                        //IYoutubeViewerRepository = new YoutubeViewerRepository(connectionString);
                        break;
                    case RepositoryType.EFCore:
                        IYoutubeViewerRepository = new YoutubeViewerRepositoryEF(connectionString);
                        break;
                    default: throw new YouTubeViewerDataLayerFactoryException("GeefRepostory");
                }
            }
            catch (Exception ex)
            {
                throw new YouTubeViewerDataLayerFactoryException("GeefRepository", ex);

            }
        }
    }
}
