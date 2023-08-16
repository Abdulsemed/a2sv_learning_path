using CleanBlogApp.Application.DTOs.Post;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanBlogApp.Application.Features.Posts.Requests.Commands;

public class UpdatePostCommand : IRequest<Unit>
{
    public UpdatePostDTO UpdatePostDTO { get; set; }
}
