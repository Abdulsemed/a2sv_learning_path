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

public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand, Unit>
{
    private readonly IPostRepository _postRepository;
    private readonly IMapper _mapper;
    public UpdatePostCommandHandler(IPostRepository postRepository, IMapper mapper)
    {
        _postRepository = postRepository;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
    {
        var post = await _postRepository.Get(request.UpdatePostDTO.id);
        if (post != null) {
            _mapper.Map(request.UpdatePostDTO, post);
            await _postRepository.Update(post);
        }
       
        return Unit.Value;
    }
}
