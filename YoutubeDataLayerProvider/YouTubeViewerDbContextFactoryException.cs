using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeViewers.DataLayerProvider
{
    public class YouTubeViewerDbContextFactoryException : Exception
    {
        public YouTubeViewerDbContextFactoryException() : base() { }

        public YouTubeViewerDbContextFactoryException(string message) : base(message) { }
        public YouTubeViewerDbContextFactoryException(string message, Exception ex) : base(message, ex) { }

    }
}
