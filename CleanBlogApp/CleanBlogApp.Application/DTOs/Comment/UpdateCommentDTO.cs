using CleanBlogApp.Application.DTOs.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanBlogApp.Application.DTOs.Comment;

public class UpdateCommentDTO : BaseDTO
{
    public string Text { get; set; } = "";
}
