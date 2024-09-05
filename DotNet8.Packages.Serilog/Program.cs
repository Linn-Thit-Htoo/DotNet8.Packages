using Serilog.Formatting.Compact;
using Serilog.Templates;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.File(
        new CompactJsonFormatter(),
        "logs/logs.txt",
        rollingInterval: RollingInterval.Hour
    )
    .WriteTo.Console(new ExpressionTemplate("[{@t:HH:mm:ss} {@l:u3} {SourceContext}] {@m}\n{@x}"))
    //      .WriteTo
    //.MSSqlServer(
    //    connectionString: builder.Configuration.GetConnectionString("DbConnection"),
    //    sinkOptions: new MSSqlServerSinkOptions { TableName = "Tbl_Logs", AutoCreateSqlTable = true })
    .CreateLogger();

// Add services to the container.

builder.Host.UseSerilog();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
