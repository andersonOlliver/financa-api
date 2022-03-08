using Financa.Api.Middlewares;
using Financa.Api.Setup;
using Financa.CrossCuting.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add to work in docker container
//builder.WebHost.UseKestrel(options => { options.Listen(IPAddress.Any, 80); });
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
builder.Services.InitializeDatabase(builder.Configuration);
// Add services to the container.
builder.Services.InitializeDependencies();

//AppDomain.CurrentDomain.GetAssemblies().Select(a => a.FullName).ToList().ForEach(a => Console.WriteLine(a));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllers().AddJsonOptions(x =>
{
    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();
builder.Services.AddCors();

var app = builder.Build();
app.MigrateDatabase();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
}
else
{
    app.UseHttpsRedirection();
}


app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseMiddleware<JwtMiddleware>();

app.Run();
