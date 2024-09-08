using Microsoft.AspNetCore.Mvc;

namespace Posts.API.Controllers;

[ApiController]
[Route("posts")]
public sealed class PostsController(IPostService postService) : ControllerBase
{
    [HttpGet]
    public Task<IReadOnlyCollection<PostModel>> GetAll(CancellationToken cancellationToken = default)
    {
        return postService.GetAll(cancellationToken);
    }
    
    [HttpPost]
    public Task<PostModel> Create([FromBody] PostPayload payload, CancellationToken cancellationToken = default)
    {
        return postService.Create(payload, cancellationToken);
    }
    
    [HttpPut("{id:guid}")]
    public Task<PostModel> Update([FromRoute] Guid id, [FromBody] PostPayload payload, CancellationToken cancellationToken = default)
    {
        return postService.Update(id, payload, cancellationToken);
    }
    
    [HttpDelete("{id:guid}")]
    public Task Delete([FromRoute] Guid id, CancellationToken cancellationToken = default)
    {
        return postService.Delete(id, cancellationToken);
    }
}