using AutoMapper;
using CleanBlogApp.Application.Features.Posts.Requests.Commands;
using CleanBlogApp.Application.Persistence.contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanBlogApp.Application.Features.Posts.Handlers.Commands;

public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand>
{
    private readonly IPostRepository _postRepository;
    private readonly IMapper _mapper;
    public DeletePostCommandHandler(IPostRepository postRepository, IMapper mapper)
    {
        _postRepository = postRepository;
        _mapper = mapper;

    }
    public async Task Handle(DeletePostCommand request, CancellationToken cancellationToken)
    {
        var post = await _postRepository.Get(request.Id);
        if (post != null) {
            await _postRepository.Delete(post);
        }
        

    }
}
