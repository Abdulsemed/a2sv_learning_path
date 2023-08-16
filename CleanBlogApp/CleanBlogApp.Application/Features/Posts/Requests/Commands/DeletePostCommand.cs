using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanBlogApp.Application.Features.Posts.Requests.Commands;

public class DeletePostCommand : IRequest
{
    public int Id { get; set; }
}
