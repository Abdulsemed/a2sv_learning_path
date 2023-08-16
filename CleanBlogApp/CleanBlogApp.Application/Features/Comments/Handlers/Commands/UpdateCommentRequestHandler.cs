using AutoMapper;
using CleanBlogApp.Application.Features.Comments.Requests.Commands;
using CleanBlogApp.Application.Persistence.contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanBlogApp.Application.Features.Comments.Handlers.Commands;

public class UpdateCommentRequestHandler : IRequestHandler<UpdateCommentRequest, Unit>
{
    private readonly ICommentRepository _commentRepository;
    private readonly IMapper _mapper;
    public UpdateCommentRequestHandler(ICommentRepository commentRepository, IMapper mapper)
    {
        _commentRepository = commentRepository;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(UpdateCommentRequest request, CancellationToken cancellationToken)
    {
        var comment = await _commentRepository.GetCommentWithDetails(request.UpdateComment.id);
        if ( comment != null)
        {
            _mapper.Map(request.UpdateComment, comment);
            await _commentRepository.Update(comment);
        }
        
        return Unit.Value;

    }
}
