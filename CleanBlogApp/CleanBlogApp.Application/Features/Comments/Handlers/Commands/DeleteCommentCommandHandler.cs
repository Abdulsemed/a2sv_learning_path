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

public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand>
{
    private readonly ICommentRepository _commentRepository;
    private readonly IMapper _mapper;
    public DeleteCommentCommandHandler(ICommentRepository commentRepository, IMapper mapper)
    {
        _commentRepository = commentRepository;
        _mapper = mapper;
    }
    public async Task Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = await _commentRepository.GetCommentWithDetails(request.Id);
        if (comment != null)
        {
            await _commentRepository.Delete(comment);
        }
    }
}
