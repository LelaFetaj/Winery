using Winery.API.Data.Contexts;
using Winery.API.Repositories.Sectors;
using Winery.API.Repositories.Tanks;
using Winery.API.Services.Sectors;
using Winery.API.Services.Tanks;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<WineryDbContext>();
builder.Services.AddScoped<WineryDbContext>();
builder.Services.AddTransient<ISectorRepository, SectorRepository>();
builder.Services.AddTransient<ITankRepository, TankRepository>();
builder.Services.AddTransient<ISectorService, SectorService>();
builder.Services.AddTransient<ITankService, TankService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
