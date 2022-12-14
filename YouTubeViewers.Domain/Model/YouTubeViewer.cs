using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeViewers.Domain.Model
{
    public class YouTubeViewer
    {
        public Guid Id { get; }
        public string Username { get; }
        public bool IsSubscribed { get; }
        public bool IsMember { get; }


        public YouTubeViewer() { }


        private YouTubeViewer(Guid id, string username, bool isSubscribed, bool isMember)
        {
            Id = id;
            Username = username;
            IsSubscribed = isSubscribed;
            IsMember = isMember;
        }

        public static YouTubeViewer CreateYouTubeViewerWithId(Guid id, string username, bool isSubscribed, bool isMember)
        {
            return new YouTubeViewer(id, username, isSubscribed, isMember);
        }
    }
}
