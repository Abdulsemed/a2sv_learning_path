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

public class GetCommentDetailsRequestHandler : IRequestHandler<GetCommentDetailsRequest, CommentDTO>
{
    private readonly ICommentRepository _commentRepository;
    private readonly IMapper _mapper;
    public GetCommentDetailsRequestHandler(ICommentRepository commentRepository, IMapper mapper)
    {
        _commentRepository = commentRepository;
        _mapper = mapper;
    }
    public async Task<CommentDTO> Handle(GetCommentDetailsRequest request, CancellationToken cancellationToken)
    {
        var comment = await _commentRepository.GetCommentWithDetails(request.commentId);
        return _mapper.Map<CommentDTO>(comment);
    }
}
