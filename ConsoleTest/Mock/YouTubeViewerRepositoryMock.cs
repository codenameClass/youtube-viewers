using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeViewers.Domain.Interfaces;
using YouTubeViewers.Domain.Model;

namespace ConsoleTest.Mock
{
    public class YouTubeViewerRepositoryMock : IYouTubeViewerRepository
    {
        private List<YouTubeViewer> _youTubeViewers;

        public YouTubeViewerRepositoryMock()
        {
            _youTubeViewers = new()
            {
                YouTubeViewer.CreateYouTubeViewerWithId(Guid.NewGuid(), "test123", true, false),
                YouTubeViewer.CreateYouTubeViewerWithId(Guid.NewGuid(), "test321", false, false),
                YouTubeViewer.CreateYouTubeViewerWithId(Guid.NewGuid(), "test1000", true, true)
            };
        }

        public Task Add(YouTubeViewer youTubeViewer)
        {
            _youTubeViewers.Add(youTubeViewer);

            return Task.FromResult(youTubeViewer);
        }

        public Task Delete(Guid id)
        {
            var youTubeViewer = _youTubeViewers.FirstOrDefault(y => y.Id == id);
            if (youTubeViewer == null) new Exception();

            return Task.FromResult(_youTubeViewers.Remove(youTubeViewer));
        }

        public Task<List<YouTubeViewer>> Load()
        {
            return Task.FromResult(_youTubeViewers);
        }

        public Task Update(YouTubeViewer youTubeViewer)
        {
            _youTubeViewers[_youTubeViewers.FindIndex(y => y.Id == youTubeViewer.Id)] = youTubeViewer;

            return Task.FromResult(youTubeViewer);
        }
    }
}
