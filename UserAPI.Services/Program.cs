using UserAPI.Services.Configurations;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddRouting(x => x.LowercaseQueryStrings = true);

SwaggerConfiguration.Configure(builder);

JwtConfiguration.Configure(builder);

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
