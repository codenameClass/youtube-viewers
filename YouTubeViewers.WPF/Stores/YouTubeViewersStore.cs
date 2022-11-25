using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using YouTubeViewers.Domain.Interfaces;
using YouTubeViewers.Domain.Models;

namespace YouTubeViewers.WPF.Stores
{
    public class YouTubeViewersStore
    {
        private readonly IYouTubeViewerService _youTubeViewerService;
        private readonly List<YouTubeViewer> _youTubeViewers;
        public IEnumerable<YouTubeViewer> YouTubeViewers => _youTubeViewers;

        public event Action YouTubeViewersLoaded;
        public event Action<YouTubeViewer> YouTubeViewerAdded;
        public event Action<YouTubeViewer> YouTubeViewerUpdated;
        public event Action<Guid> YouTubeViewerDeleted;

        public YouTubeViewersStore(IYouTubeViewerService youTubeViewerService)
        {
            _youTubeViewerService = youTubeViewerService;
            _youTubeViewers = new List<YouTubeViewer>();
        }

        public async Task Load()
        {
            List<YouTubeViewer> youTubeViewers = await _youTubeViewerService.GetAllYouTubeViewers();

            _youTubeViewers.Clear();
            _youTubeViewers.AddRange(youTubeViewers);

            YouTubeViewersLoaded?.Invoke();
        }

        public async Task Add(Guid id, string username, bool isSubscribed, bool isMember)
        {
            YouTubeViewer createdYouTubeViewer = await _youTubeViewerService.CreateYouTubeViewer(id, username, isSubscribed, isMember);
            _youTubeViewers.Add(createdYouTubeViewer);

            YouTubeViewerAdded?.Invoke(createdYouTubeViewer);
        }

        public async Task Update(Guid id, string username, bool isSubscribed, bool isMember)
        {
            YouTubeViewer updatedyYouTubeViewer = await _youTubeViewerService.UpdateYouTubeViewer(id, username, isSubscribed, isMember);
            int currentIndex = _youTubeViewers.FindIndex(y => y.Id == id);

            if(currentIndex != -1)
            {
                _youTubeViewers[currentIndex] = updatedyYouTubeViewer;
            }
            else
            {
                _youTubeViewers.Add(updatedyYouTubeViewer);
            }

            YouTubeViewerUpdated?.Invoke(updatedyYouTubeViewer);
        }

        public async Task Delete(Guid id)
        {
            await _youTubeViewerService.DeleteYouTubeViewer(id);
            _youTubeViewers.RemoveAll(y => y.Id == id);

            YouTubeViewerDeleted?.Invoke(id);
        }
    }
}
