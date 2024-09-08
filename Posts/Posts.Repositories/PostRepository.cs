using Microsoft.EntityFrameworkCore;

namespace Posts.Repositories;

internal sealed class PostRepository(PostDbContext context) : IPostRepository
{
    public async Task<IReadOnlyCollection<PostModel>> GetAll(CancellationToken cancellationToken = default)
    {
        return await context.Posts.Select(q => ToModel(q)).ToArrayAsync(cancellationToken: cancellationToken);
    }

    public async Task<PostModel> Create(PostModel model, CancellationToken cancellationToken = default)
    {
        var entity = ToEntity(model);

        await context.Posts.AddAsync(entity, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return ToModel(entity);
    }

    public async Task<PostModel> Update(PostModel model, CancellationToken cancellationToken = default)
    {
        var entity = await context.Posts.FindAsync(model.Id);

        entity.Title = model.Title;
        entity.Text = model.Text;
        entity.ModifiedDate = model.ModifiedDate;
        
        await context.SaveChangesAsync(cancellationToken);
        return ToModel(entity);
    }

    public Task Delete(Guid id, CancellationToken cancellationToken = default)
    {
        return context.Posts.Where(q => q.Id == id).ExecuteDeleteAsync(cancellationToken);
    }

    private static PostModel ToModel(Post post) => new(post.Id, post.Title, post.Text, post.CreatedDate, post.ModifiedDate);

    private static Post ToEntity(PostModel post) => new(post.Id, post.Title, post.Text, post.CreatedDate, post.ModifiedDate);
}