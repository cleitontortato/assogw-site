using System.Collections.Generic;

namespace assogw.Models
{
    public class NewsDetailsViewModel
    {
        public NewsItem Article { get; set; }
        public List<NewsItem> RecentNews { get; set; }
    }
}
