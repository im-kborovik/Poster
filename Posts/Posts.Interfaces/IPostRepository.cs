namespace Posts;

public interface IPostRepository
{
    Task<IReadOnlyCollection<PostModel>> GetAll(CancellationToken cancellationToken = default);

    Task<PostModel> Create(PostModel model, CancellationToken cancellationToken = default);

    Task<PostModel> Update(PostModel model, CancellationToken cancellationToken = default);

    Task Delete(Guid id, CancellationToken cancellationToken = default);
}