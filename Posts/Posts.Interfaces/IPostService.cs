namespace Posts;

public interface IPostService
{
    Task<IReadOnlyCollection<PostModel>> GetAll(CancellationToken cancellationToken = default);

    Task<PostModel> Create(PostPayload payload, CancellationToken cancellationToken = default);

    Task<PostModel> Update(Guid id, PostPayload payload, CancellationToken cancellationToken = default);

    Task Delete(Guid id, CancellationToken cancellationToken = default);

}