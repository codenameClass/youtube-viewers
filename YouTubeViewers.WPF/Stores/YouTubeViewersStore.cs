using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using YouTubeViewers.Domain.Interfaces;
using YouTubeViewers.Domain.Models;

namespace YouTubeViewers.WPF.Stores
{
    public class YouTubeViewersStore
    {
        private readonly IYouTubeViewerRepository _YouTubeViewerRepository;
        private readonly List<YouTubeViewer> _youTubeViewers;
        public IEnumerable<YouTubeViewer> YouTubeViewers => _youTubeViewers;

        public event Action YouTubeViewersLoaded;
        public event Action<YouTubeViewer> YouTubeViewerAdded;
        public event Action<YouTubeViewer> YouTubeViewerUpdated;
        public event Action<Guid> YouTubeViewerDeleted;

        public YouTubeViewersStore(IYouTubeViewerRepository IYoutubeViewerRepository)
        {
            _YouTubeViewerRepository = IYoutubeViewerRepository;
            _youTubeViewers = new List<YouTubeViewer>();
        }

        public async Task Load()
        {
            List<YouTubeViewer> youTubeViewers = await _YouTubeViewerRepository.Load();

            _youTubeViewers.Clear();
            _youTubeViewers.AddRange(youTubeViewers);

            YouTubeViewersLoaded?.Invoke();
        }

        public async Task Add(YouTubeViewer youTubeViewer)
        {
            await _YouTubeViewerRepository.Add(youTubeViewer);

            _youTubeViewers.Add(youTubeViewer);

            YouTubeViewerAdded?.Invoke(youTubeViewer);
        }

        public async Task Update(YouTubeViewer youTubeViewer)
        {
            await _YouTubeViewerRepository.Update(youTubeViewer);
            int currentIndex = _youTubeViewers.FindIndex(y => y.Id == youTubeViewer.Id);

            if(currentIndex != -1)
            {
                _youTubeViewers[currentIndex] = youTubeViewer;
            }
            else
            {
                _youTubeViewers.Add(youTubeViewer);
            }

            YouTubeViewerUpdated?.Invoke(youTubeViewer);
        }

        public async Task Delete(Guid id)
        {
            await _YouTubeViewerRepository.Delete(id);
            _youTubeViewers.RemoveAll(y => y.Id == id);

            YouTubeViewerDeleted?.Invoke(id);
        }
    }
}
