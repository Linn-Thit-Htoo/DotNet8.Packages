using DinkToPdf;
using DinkToPdf.Contracts;
using DotNet8.Packages.DrinkToPdf.Models;

namespace DotNet8.Packages.DrinkToPdf.Services
{
    public class PDFService : IPDFService
    {
        private readonly IConverter _converter;

        public PDFService(IConverter converter)
        {
            _converter = converter;
        }

        public Task<byte[]> GeneratePdf(string htmlContent)
        {
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings
                {
                    Top = 20,
                    Bottom = 10,
                    Left = 30,
                    Right = 30
                },
                DocumentTitle = "User",
            };

            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = htmlContent,
                WebSettings = { DefaultEncoding = "utf-8" },
                HeaderSettings =
            {
                FontSize = 8,
                Right = "Page [page] of [toPage]",
                Line = true,
                Spacing = 2.812
            },
                FooterSettings =
            {
                FontSize = 8,
                Right = "Page [page] of [toPage]",
                Line = true,
                Spacing = 2.812
            },
            };

            var document = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };

            return Task.FromResult(_converter.Convert(document));
        }

        public Task<string> GetHtml(UserModel user)
        {
            string htmlStr =
                $@"
        <!doctype html>
        <html lang=""en"">
            <head>
                <style>
                    .header {{
                        text-align: center;
                        color: green;
                        padding-bottom: 35px;
                    }}

                    table {{
                        width: 80%;
                        border-collapse: collapse;
                        margin: 0 auto;
                    }}

                    td, th {{
                        border: 1px solid gray;
                        padding: 15px;
                        font-size: 22px;
                        text-align: center;
                    }}

                    table th {{
                        background-color: green;
                        color: white;
                    }}
                </style>
            </head>
            <body>
                <!-- Begin page content -->
                <main role=""main"" class=""container"">
                    <table>
                        <thead>
                            <tr>
                                <th>Property</th>
                                <th>Value</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>UserId</td>
                                <td>{user.UserId}</td>
                            </tr>
                            <tr>
                                <td>UserName</td>
                                <td>{user.UserName}</td>
                            </tr>
                            <tr>
                                <td>UserRole</td>
                                <td>{user.UserRole}</td>
                            </tr>
                            <tr>
                                <td>IsActive</td>
                                <td>{user.IsActive}</td>
                            </tr>
                        </tbody>
                    </table>
                </main>
            </body>
        </html>
    ";

            return Task.FromResult(htmlStr);
        }
    }
}
