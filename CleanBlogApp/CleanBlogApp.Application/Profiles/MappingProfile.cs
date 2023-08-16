using AutoMapper;
using CleanBlogApp.Application.DTOs.Comment;
using CleanBlogApp.Application.DTOs.Post;
using CleanBlogApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanBlogApp.Application.Profiles;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Post,PostDTO>().ReverseMap();
        CreateMap<Comment, CommentDTO>().ReverseMap();
    }
}
