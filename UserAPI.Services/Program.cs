using Microsoft.EntityFrameworkCore;
using UserAPI.Domain.Interfaces.Repositories;
using UserAPI.Infra.Context;
using UserAPI.Infra.Repositories;
using UserAPI.Services.Configurations;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddRouting(x => x.LowercaseQueryStrings = true);
builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

SwaggerConfiguration.Configure(builder);
JwtConfiguration.Configure(builder);
DependencyInjectionConfiguration.Configure(builder);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }
