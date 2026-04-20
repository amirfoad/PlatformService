using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


//builder.Services.AddAutoMapper(opt =>
//{
//    opt.AddProfile<CommandProfile>();
//},
//typeof(Program).Assembly);

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();


app.MapOpenApi();
app.MapScalarApiReference(opt =>
{
    opt.Title = "Command Service API";
    opt.Theme = ScalarTheme.Purple;
    opt.DefaultHttpClient = new(ScalarTarget.CSharp, ScalarClient.HttpClient);
});


app.UseAuthorization();

app.MapControllers();

app.Run();
