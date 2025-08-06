using PetFamily.Infractructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<ApplicationDBContext>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.Run();
