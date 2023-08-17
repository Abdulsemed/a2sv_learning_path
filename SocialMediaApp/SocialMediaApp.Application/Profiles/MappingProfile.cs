using AutoMapper;
using SocialMediaApp.Application.DTOs.Comments;
using SocialMediaApp.Application.DTOs.Follows;
using SocialMediaApp.Application.DTOs.Likes;
using SocialMediaApp.Application.DTOs.Notifications;
using SocialMediaApp.Application.DTOs.Posts;
using SocialMediaApp.Application.DTOs.Users;
using SocialMediaApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<Post, PostDto>().ReverseMap();
        CreateMap<Comment, CommentDto>().ReverseMap();
        CreateMap<Like, LikeDto>().ReverseMap();
        CreateMap<Follow, FollowDto>().ReverseMap();
        CreateMap<Notification, NotificationDto>().ReverseMap();
    }
}
