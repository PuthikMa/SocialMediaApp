﻿using AutoMapper;
using SocialMedia.API.Domain.Identity;
using SocialMedia.API.Domain.Models;

namespace SocialMedia.API.Domain.Dtos
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Post, PostDto>();
            CreateMap<PostDto, Post>();
            CreateMap<Comment, CommentDto>();
            CreateMap<CommentDto, Comment>();
            CreateMap<Photo, PhotoDto>();
            CreateMap<PhotoDto, Photo>();
            CreateMap<AppUserDto, AppUser>();
            CreateMap<AppUser, AppUserDto>();
            CreateMap<PostEmotionDto, PostEmotion>();
            CreateMap<PostEmotion, PostEmotionDto>();
        }
    }
}
