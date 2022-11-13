using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.FileProviders;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseStaticFiles();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    string clientPath = System.IO.Directory.GetParent(builder.Environment.ContentRootPath).Parent.ToString();
    string distPath = @"Client/dist/";

    app.UseStaticFiles(new StaticFileOptions()
    {
        FileProvider = new PhysicalFileProvider(Path.Combine(clientPath, distPath))
    });
}

if (app.Environment.IsProduction())
{
    string clientPath = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "/dist");

    var clientAppFileProvider = new PhysicalFileProvider(clientPath);

    app.UseSpaStaticFiles(new StaticFileOptions
    {
        FileProvider = clientAppFileProvider,
    });
}

app.UseAuthorization();

app.MapControllers();


app.Run();

