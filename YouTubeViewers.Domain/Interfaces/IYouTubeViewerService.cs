using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeViewers.Domain.Model;

namespace YouTubeViewers.Domain.Interfaces
{
    public interface IYouTubeViewerService
    {
        Task<YouTubeViewer> CreateYouTubeViewer(Guid id, string username, bool isSubscribed, bool isMember);
        Task<YouTubeViewer> UpdateYouTubeViewer(Guid id, string username, bool isSubscribed, bool isMember);
        Task DeleteYouTubeViewer(Guid id);
        Task<List<YouTubeViewer>> GetAllYouTubeViewers();
    }
}
