using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeViewers.DataLayerProvider
{
    public class YouTubeViewerDataLayerFactoryException : Exception
    {
        public YouTubeViewerDataLayerFactoryException() : base() { }

        public YouTubeViewerDataLayerFactoryException(string message) : base(message) { }
        public YouTubeViewerDataLayerFactoryException(string message, Exception ex) : base(message, ex) { }

    }
}
