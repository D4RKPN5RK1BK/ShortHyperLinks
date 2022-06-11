namespace ShortHyperLinks.Data
{
    public class HyperLink
    {
        public long Id { get; set; }
        public string OriginalLink { get; set; }
        public string ShortLink { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
