using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdresbeheerMDBlayer.Exceptions
{
    public class YoutubeViewerRepositoryException : Exception
    {
        public YoutubeViewerRepositoryException(string message) : base(message)
        {
        }

        public YoutubeViewerRepositoryException(string message, Exception innerException) : base(message, innerException) { 
        }
    }
}
