using AutoMapper;
using CleanBlogApp.Application.Persistence.contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using CleanBlogApp.Domain;
using CleanBlogApp.Application.Features.Posts.Requests.Commands;

namespace CleanBlogApp.Application.Features.Posts.Handlers.Commands;

public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, int>
{
    private readonly IPostRepository _postRepository;
    private readonly IMapper _mapper;
    public CreatePostCommandHandler(IPostRepository postRepository, IMapper mapper)
    {
        _postRepository = postRepository;
        _mapper = mapper;

    }
    public async Task<int> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        var post = _mapper.Map<Post>(request.CreatePostDTO);
        post = await _postRepository.Add(post);
        return post.id;
    }
}
