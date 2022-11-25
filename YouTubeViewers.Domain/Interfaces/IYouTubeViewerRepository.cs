using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeViewers.Domain.Models;

namespace YouTubeViewers.Domain.Interfaces
{
    public interface IYouTubeViewerRepository {

        public Task Update(YouTubeViewer youTubeViewer);
        public Task Delete(Guid id);
        public Task Add(YouTubeViewer youTubeViewer);
        public Task<List<YouTubeViewer>> Load();

    }
}
