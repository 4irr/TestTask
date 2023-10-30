using API;
using API.Middleware;
using Application;
using Application.Common.Mappings;
using Application.Interfaces;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Persistence;
using Security;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new AssemblyMappingProfile(typeof(IApplicationContext).Assembly));
});

builder.Services.AddControllers();
builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddCustomJwtGenerator(builder.Configuration);
builder.Services.AddCustomAuthentication(builder.Configuration);
builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCustomExceptionHandler();
app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();

app.UseAuthentication();
app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI(config =>
{
    config.RoutePrefix = string.Empty;
    config.SwaggerEndpoint("swagger/Test Task API/swagger.json", "Test Task API");
});

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<ApplicationContext>();
        var userManager = services.GetRequiredService<UserManager<AppUser>>();
        context.Database.Migrate();
        DataSeed.SeedDataAsync(context, userManager).Wait();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occured during migration");
    }
}

app.Run();
