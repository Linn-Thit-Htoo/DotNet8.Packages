namespace DotNet8.Packages.FluentValidation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlogController : ControllerBase
{
    private readonly BlogValidator _blogValidator;

    public BlogController(BlogValidator blogValidator)
    {
        _blogValidator = blogValidator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateBlog([FromBody] BlogRequestDto blogRequest)
    {
        var validationResult = await _blogValidator.ValidateAsync(blogRequest);
        if (!validationResult.IsValid)
        {
            string errors = string.Join(" ", validationResult.Errors.Select(x => x.ErrorMessage));
            return BadRequest(errors);
        }

        return Ok();
    }
}
