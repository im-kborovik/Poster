namespace Posts.Repositories;

public sealed class Post
{
    public Post()
    {
    }

    public Post(Guid id, string title, string text, DateTime createdDate, DateTime? modifiedDate)
    {
        Id = id;
        Title = title;
        Text = text;
        CreatedDate = createdDate;
        ModifiedDate = modifiedDate;
    }

    public Guid Id { get; set; }

    public string Title { get; set; }

    public string Text { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }
}