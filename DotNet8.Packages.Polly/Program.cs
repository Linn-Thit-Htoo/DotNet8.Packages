using Dumpify;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Extensions.Http;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var retryPolicy = HttpPolicyExtensions
    .HandleTransientHttpError()
    .WaitAndRetryAsync(
        retryCount: 3,
        sleepDurationProvider: attempt => TimeSpan.FromSeconds(3),
        onRetry: (outcome, timespan, retryAttempt, context) =>
        {
            string message =
                $"Retrying due to: {outcome.Exception?.Message ?? outcome.Result.ReasonPhrase}. Wait time: {timespan}. Attempt: {retryAttempt}.";
            message.Dump();
        }
    );

builder.Services.AddHttpClient("ExampleClient", httpClient =>
{
    httpClient.BaseAddress = new Uri(builder.Configuration.GetSection("SampleUri").Value!);
    httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
    httpClient.Timeout = TimeSpan.FromSeconds(30);
});

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
