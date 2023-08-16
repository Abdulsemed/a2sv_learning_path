using AutoMapper;
using CleanBlogApp.Application.DTOs.Post;
using CleanBlogApp.Application.Features.Posts.Requests.Queries;
using CleanBlogApp.Application.Persistence.contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanBlogApp.Application.Features.Posts.Handlers.Queries;
public class GetPostsRequestHandler : IRequestHandler<GetPostsRequest, List<PostDTO>>
{
    private readonly IPostRepository _postRepository;
    private readonly IMapper _mapper;
    public GetPostsRequestHandler(IPostRepository postRepository,IMapper mapper)
    {
        _mapper = mapper;
        _postRepository = postRepository;
    }
    public async Task<List<PostDTO>> Handle(GetPostsRequest request, CancellationToken cancellationToken)
    {
        var posts = await _postRepository.GetAll();

        return _mapper.Map<List<PostDTO>>(posts);
        
    }
}
