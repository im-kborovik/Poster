namespace Posts;

public sealed record PostModel(Guid Id, string Title, string Text, DateTime CreatedDate, DateTime? ModifiedDate);