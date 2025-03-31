public class Review {
    public string Author { get; private set; }
    public string Content { get; private set; }
    public DateTime PublishedAt { get; private set; }

    public Review(string author, string content, DateTime publishedAt) {
        Author = author;
        Content = content;
        PublishedAt = publishedAt;
    }
}