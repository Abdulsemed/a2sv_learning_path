using System;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanBlogApp.Application.Features.Posts.Requests;
using CleanBlogApp.Application.Persistence.contracts;
using AutoMapper;
using CleanBlogApp.Application.DTOs.Post;

namespace CleanBlogApp.Application.Features.Posts.Requests.Queries;
public class GetPostDetailsRequestHandler : IRequestHandler<GetPostDetailsRequest, PostDTO>
{
    private readonly IPostRepository _postRepository;
    private readonly IMapper _mapper;
    public GetPostDetailsRequestHandler(IPostRepository postRepository, IMapper mapper)
    {
        _postRepository = postRepository;
        _mapper = mapper;
    }
    public async Task<PostDTO> Handle(GetPostDetailsRequest request, CancellationToken cancellationToken)
    {
        var post = await _postRepository.Get(request.Id);
        return _mapper.Map<PostDTO>(post);
    }
}
