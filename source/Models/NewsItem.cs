namespace assogw.Models
{
    public class NewsItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Excerpt { get; set; }
        public string ImageUrl { get; set; }
        public DateTime PublishDate { get; set; }
        public string Author { get; set; }
    }
}
