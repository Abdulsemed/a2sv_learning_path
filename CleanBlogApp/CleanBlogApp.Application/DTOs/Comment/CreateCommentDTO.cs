using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanBlogApp.Application.DTOs.Comment;

public class CreateCommentDTO
{
    public int postId { get; set; }
    public string Text { get; set; } = "";
}
