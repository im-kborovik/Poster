namespace Posts.Services;

internal sealed class PostService(IPostRepository repository) : IPostService
{
    public Task<IReadOnlyCollection<PostModel>> GetAll(CancellationToken cancellationToken = default)
    {
        return repository.GetAll(cancellationToken);
    }

    public Task<PostModel> Create(PostPayload payload, CancellationToken cancellationToken = default)
    {
        var model = new PostModel(Guid.Empty, payload.Title, payload.Text, DateTime.UtcNow, null);
        return repository.Create(model, cancellationToken);
    }

    public Task<PostModel> Update(Guid id, PostPayload payload, CancellationToken cancellationToken = default)
    {
        var model = new PostModel(id, payload.Title, payload.Text, DateTime.UtcNow, DateTime.UtcNow);
        return repository.Update(model, cancellationToken);
    }

    public Task Delete(Guid id, CancellationToken cancellationToken = default)
    {
        return repository.Delete(id, cancellationToken);
    }
}