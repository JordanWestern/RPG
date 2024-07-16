using Microsoft.EntityFrameworkCore;
using RPG.App;
using RPG.App.Services;
using RPG.Domain.Events;
using RPG.Domain.Factories;
using RPG.Domain.Repositories;
using RPG.Infrastructure.DbContexts;
using RPG.Infrastructure.Events;
using RPG.Infrastructure.Repositories;
using static RPG.Domain.Entities.GameLog;
using static RPG.Domain.Entities.Player;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IGameEventService, GameEventService>();
builder.Services.AddScoped<IGameLogService, GameLogService>();
builder.Services.AddScoped<IPlayerService, PlayerService>();

builder.Services.AddTransient<IGuidFactory, GuidFactory>();
builder.Services.AddTransient<IPlayerFactory, PlayerFactory>();
builder.Services.AddTransient<IGameLogFactory, GameLogFactory>();

builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();
builder.Services.AddScoped<IGameLogRepository, GameLogRepository>();

builder.Services.AddDbContext<PlayerDbContext>(optionsBuilder => optionsBuilder.UseInMemoryDatabase("Players"));
builder.Services.AddDbContext<GameLogDbContext>(optionsBuilder => optionsBuilder.UseInMemoryDatabase("GameLogs"));

builder.Services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(typeof(PlayerCreatedEventHandler).Assembly));

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
