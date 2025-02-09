using GB_Assigment.Configurations;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

SetupConfiguration(builder);
SetupLogging(builder);  

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
static void SetupConfiguration(WebApplicationBuilder builder)
{
    builder.Services.AddControllers();
    builder.Services.AddSwagger();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddRepositories();
    builder.Services.AddServices();
}

static void SetupLogging(WebApplicationBuilder builder)
{
    var logger = new LoggerConfiguration()
                                .ReadFrom.Configuration(builder.Configuration)
                                .Enrich.FromLogContext()
                                .CreateLogger();
    builder.Logging.ClearProviders();
    builder.Logging.AddSerilog(logger);
}
