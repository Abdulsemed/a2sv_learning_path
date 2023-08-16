using AutoMapper;
using CleanBlogApp.Application.Features.Comments.Requests.Commands;
using CleanBlogApp.Application.Persistence.contracts;
using CleanBlogApp.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanBlogApp.Application.Features.Comments.Handlers.Commands;

public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, int>
{
    private readonly ICommentRepository _commentRepository;
    private readonly IMapper _mapper;
    public CreateCommentCommandHandler(ICommentRepository commentRepository, IMapper mapper)
    {
        _commentRepository = commentRepository;
        _mapper = mapper;
    }
    public async Task<int> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = _mapper.Map<Comment>(request.Comment);
        comment = await _commentRepository.Add(comment);
        return comment.id;
    }
}
