using AutoMapper;
using CleanBlogApp.Application.DTOs.Comment;
using CleanBlogApp.Application.Features.Comments.Requests.Queries;
using CleanBlogApp.Application.Persistence.contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanBlogApp.Application.Features.Comments.Handlers.Queries;

public class GetCommentsRequestHandler : IRequestHandler<GetCommentsRequest, List<CommentDTO>>
{
    private readonly ICommentRepository _commentRepository;
    private readonly IMapper _mapper;
    public GetCommentsRequestHandler(ICommentRepository commentRepository, IMapper mapper)
    {
        _commentRepository = commentRepository;
        _mapper = mapper;
    }
    public async Task<List<CommentDTO>> Handle(GetCommentsRequest request, CancellationToken cancellationToken)
    {
        var comments = await _commentRepository.GetComments(request.postId);
        return _mapper.Map<List<CommentDTO>>(comments);
    }
}
