using RPG.App;
using RPG.App.Events;
using RPG.App.Services;
using RPG.Domain.Entities;
using RPG.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSignalR();
builder.Services.AddScoped<IGameEventService, GameEventService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowElectronApp",
        builder =>
        {
            builder.WithOrigins("http://localhost:3000")
                   .AllowAnyHeader()
                   .AllowAnyMethod()
                   .AllowCredentials();
        });
});

builder.Services.AddTransient<IGuidProvider, GuidProvider>();
builder.Services.AddScoped<IPlayerService, PlayerService>();
builder.Services.AddInfrastructure();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowElectronApp");

app.UseAuthorization();

app.MapHub<GameEventHub>("/gameEventHub")
    .RequireCors("AllowElectronApp");

app.MapControllers();

app.Run();
