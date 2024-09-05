namespace DotNet8.Packages.AutoMapper.Mapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<BlogRequestDto, BlogDto>()
            .ForMember(dest => dest.BlogTitle, opt => opt.MapFrom(src => src.BlogTitle))
            .ForMember(dest => dest.BlogAuthor, opt => opt.MapFrom(src => src.BlogAuthor))
            .ForMember(dest => dest.BlogContent, opt => opt.MapFrom(src => src.BlogContent));
    }
}
