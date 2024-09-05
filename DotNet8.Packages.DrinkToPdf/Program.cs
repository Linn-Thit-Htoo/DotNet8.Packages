var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var wkHtmlToPdfPath = Path.Combine(Directory.GetCurrentDirectory(), $"libs/libwkhtmltox.dll");
CustomAssemblyLoadContext context = new();
context.LoadUnmanagedLibrary(wkHtmlToPdfPath);

builder.Services.AddScoped<IPDFService, PDFService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
