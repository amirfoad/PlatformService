using Microsoft.EntityFrameworkCore;
using PlatformService.Data;
using PlatformService.Dtos.Profiles;
using PlatformService.SyncDataServices.Http;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(opt =>
opt.UseInMemoryDatabase("InMemory"));

builder.Services.AddScoped<IPlatformRepo, PlatformRepo>();

builder.Services.AddHttpClient<ICommandDataClient, HttpCommandDataClient>();

Console.WriteLine($"--> CommandService Endpoint: {builder.Configuration["CommandService"]}");

builder.Services.AddControllers();

builder.Services.AddAutoMapper(opt=>
{
    opt.AddProfile<PlatformProfile>();
},
typeof(Program).Assembly);

builder.Services.AddOpenApi();

var app = builder.Build();


    app.MapOpenApi();
    app.MapScalarApiReference(opt =>
    {
        opt.Title = "Platform Service API";
        opt.Theme = ScalarTheme.DeepSpace; 
        opt.DefaultHttpClient = new(ScalarTarget.CSharp, ScalarClient.HttpClient);
    });

app.UseAuthorization();

app.MapControllers();

PrepDb.PrepPopulation(app);

app.Run();
