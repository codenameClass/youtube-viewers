using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeViewers.Domain.Interfaces;
using YouTubeViewers.Domain.Models;

namespace YouTubeViewers.Domain.Services
{
    public class YouTubeViewerService : IYouTubeViewerService
    {
        IYouTubeViewerRepository _repo;

        public YouTubeViewerService(IYouTubeViewerRepository repo)
        {
            _repo= repo;
        }

        public Task<YouTubeViewer> CreateYouTubeViewer(Guid id, string username, bool isSubscribed, bool isMember)
        {
            YouTubeViewer youTubeViewer = YouTubeViewer.CreateYouTubeViewerWithId(id, username, isSubscribed, isMember);

            _repo.Add(youTubeViewer);

            return Task.FromResult(youTubeViewer);
        }

        public Task DeleteYouTubeViewer(Guid id)
        {
            return _repo.Delete(id);
        }

        public Task<List<YouTubeViewer>> GetAllYouTubeViewers()
        {
            return _repo.Load();
        }

        public Task<YouTubeViewer> UpdateYouTubeViewer(Guid id, string username, bool isSubscribed, bool isMember)
        {
            var updatedYouTubeViewer = YouTubeViewer.CreateYouTubeViewerWithId(id, username, isSubscribed, isMember);

            _repo.Update(updatedYouTubeViewer);

            return Task.FromResult(updatedYouTubeViewer);
        }
    }
}
