using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class CacheSettings
    {
        // SlidingExpiration =
        // number of second that if from that cache will expire
        // For Every access to cache it will reset to first value ( if it is 5 minute => 
        // after every access to cache it will update to 5 minute )

        // AbsoluteExpiration =
        // Absolute time where cache will expire at this time

        public int SlidingExpiration { get; set; }
        public string DestinationUrl { get; set; }
        public string ApplicationName { get; set; }
        public bool BypassCache { get; set; }
    }
}
