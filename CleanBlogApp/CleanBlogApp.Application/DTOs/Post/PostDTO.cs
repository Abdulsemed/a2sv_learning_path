using CleanBlogApp.Application.DTOs.Comment;
using CleanBlogApp.Application.DTOs.common;
using CleanBlogApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanBlogApp.Application.DTOs.Post;
public class PostDTO : BaseDTO
{
    public PostDTO()
    {
        Comments = new List<CommentDTO>();
    }
    public string Title { get; set; } = "";
    public string Content { get; set; } = "";
    public List<CommentDTO> Comments { get; set; }
}
