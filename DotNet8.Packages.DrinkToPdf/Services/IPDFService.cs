namespace DotNet8.Packages.DrinkToPdf.Services;

public interface IPDFService
{
    public Task<string> GetHtml(UserModel user);
    public Task<byte[]> GeneratePdf(string htmlContent);
}
