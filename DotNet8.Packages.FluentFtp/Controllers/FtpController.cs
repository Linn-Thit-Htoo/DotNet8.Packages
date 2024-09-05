namespace DotNet8.Packages.FluentFtp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FtpController : ControllerBase
{
    private readonly FtpService _ftpService;

    public FtpController(FtpService ftpService)
    {
        _ftpService = ftpService;
    }

    [HttpGet]
    public async Task<IActionResult> CheckFtpDirectory(string directoryName)
    {
        bool isExist = await _ftpService.CheckDirectoryExistsAsync(directoryName);
        return Ok(isExist);
    }
}
