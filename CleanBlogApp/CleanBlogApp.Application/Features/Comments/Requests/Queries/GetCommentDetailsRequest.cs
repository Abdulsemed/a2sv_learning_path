using CleanBlogApp.Application.DTOs.Comment;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanBlogApp.Application.Features.Comments.Requests.Queries;

public class GetCommentDetailsRequest : IRequest<CommentDTO>
{
    public int postId { get; set; }
    public int commentId { get; set; }

}
