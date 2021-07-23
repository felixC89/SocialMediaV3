using AutoMapper;
using SocialMediaV3.Core.DTOs;
using SocialMediaV3.Core.Entities;

namespace SocialMediaV3.InfraStructure.Mappings
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Post, PostDto>();
            CreateMap<PostDto, Post>();
        }
    }
}
