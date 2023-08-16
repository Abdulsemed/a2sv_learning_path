using CleanBlogApp.Application.DTOs.Post;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanBlogApp.Application.Features.Posts.Requests.Queries;
public class GetPostsRequest : IRequest<List<PostDTO>>
{

}
