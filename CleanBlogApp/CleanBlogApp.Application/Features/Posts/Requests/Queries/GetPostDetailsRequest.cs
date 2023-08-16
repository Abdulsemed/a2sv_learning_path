using System;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanBlogApp.Application.DTOs.Post;

namespace CleanBlogApp.Application.Features.Posts.Requests.Queries;
public class GetPostDetailsRequest : IRequest<PostDTO>
{
    public int Id { get; set; }
}
