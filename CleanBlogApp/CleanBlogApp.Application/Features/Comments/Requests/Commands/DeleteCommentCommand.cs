using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanBlogApp.Application.Features.Comments.Requests.Commands;

public class DeleteCommentCommand : IRequest
{
    public int Id { get; set; }
}
