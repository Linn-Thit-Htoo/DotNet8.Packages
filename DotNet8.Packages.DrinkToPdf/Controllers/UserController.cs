using DotNet8.Packages.DrinkToPdf.Models;
using DotNet8.Packages.DrinkToPdf.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotNet8.Packages.DrinkToPdf.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IPDFService _pdfService;

    public UserController(IPDFService pdfService)
    {
        _pdfService = pdfService;
    }

    [HttpPost("Generate-Pdf")]
    public async Task<IActionResult> GeneratePdf()
    {
        try
        {
            var user = new UserModel
            {
                UserId = 1,
                UserName = "Linn Thit",
                UserRole = "Admin",
                IsActive = true
            };

            var html = await _pdfService.GetHtml(user);
            var pdf = await _pdfService.GeneratePdf(html);

            return File(pdf, "application/pdf", $"{user.UserName}.pdf");
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}
