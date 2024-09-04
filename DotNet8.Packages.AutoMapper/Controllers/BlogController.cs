using AutoMapper;
using DotNet8.Packages.DTOs.Blog;
using Microsoft.AspNetCore.Mvc;

namespace DotNet8.Packages.AutoMapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IMapper _mapper;

        public BlogController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateBlog([FromBody] BlogRequestDto blogRequest)
        {
            return Ok(ToDto(blogRequest));
        }

        private BlogDto ToDto(BlogRequestDto blogRequest)
        {
            return _mapper.Map<BlogDto>(blogRequest);
        }
    }
}
