using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanBlogApp.Application.DTOs.common;

namespace CleanBlogApp.Application.DTOs.Comment;
public class CommentDTO : BaseDTO
{
    public int postId { get; set; }
    public string Text { get; set; } = "";
}
