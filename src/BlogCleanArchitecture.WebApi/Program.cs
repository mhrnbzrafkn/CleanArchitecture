using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

const string _moduleTitle = "Shop";

Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Development");

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        builder =>
        {
            builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
        });
});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddRouting();

builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "Clean Arcitecture Blog",
            Version = "v1"
        });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(options =>
    {
        options.RouteTemplate = "docs/{documentName}/swagger.json";
    });

    app.UseSwaggerUI(options =>
    {
        options.RoutePrefix = "docs";
        options.DocumentTitle = $"{_moduleTitle} API Documentation";
        options.DocExpansion(DocExpansion.None);
    });
}

if (app.Environment.IsProduction())
{
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
