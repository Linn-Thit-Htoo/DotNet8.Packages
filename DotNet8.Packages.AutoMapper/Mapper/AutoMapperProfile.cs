using AutoMapper;
using DotNet8.Packages.DbService;
using DotNet8.Packages.DTOs.Blog;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DotNet8.Packages.AutoMapper.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Tbl_Blog, BlogDto>()
                .ForMember(dest => dest.BlogId,
                opt => opt.MapFrom(src => src.BlogId))
                .ForMember(dest => dest.BlogTitle,
                opt => opt.MapFrom(src => src.BlogTitle))
                .ForMember(dest => dest.BlogAuthor,
                opt => opt.MapFrom(src => src.BlogAuthor))
                .ForMember(dest => dest.BlogContent,
                opt => opt.MapFrom(src => src.BlogContent));
        }
    }
}
