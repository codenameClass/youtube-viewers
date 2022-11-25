using YouTubeViewers.EFLayer.Exceptions;
using YouTubeViewers.EFLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using YouTubeViewers.Domain.Model;
using YouTubeViewers.EFLayer;

namespace YouTubeViewers.EFLayer.Mappers
{
    public interface MapYouTubeViewer
    {
        public static YouTubeViewerEF MapToDB(YouTubeViewer a)
        {
			try
			{
				return new YouTubeViewerEF(a.Id, a.Username, a.IsSubscribed, a.IsMember);
            }
            catch (Exception ex)
			{
				throw new MapException("MapYouTubeViewer - MapToDB", ex);
			}
        }

		public static YouTubeViewer MapToDomain(YouTubeViewerEF a)
		{
			try
			{
				return YouTubeViewer.CreateYouTubeViewerWithId(a.Id, a.Username, a.IsSubscribed, a.IsMember);
			}
			catch (Exception ex)
			{
				throw new MapException("MapYouTubeViewer - MapToDomain", ex);
			}
		}
    }
}
