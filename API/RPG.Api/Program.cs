using RPG.App;
using RPG.App.Events;
using RPG.App.Services;
using RPG.Domain.Factories;
using RPG.Domain.Repositories;
using RPG.Infrastructure.DbContexts;
using RPG.Infrastructure.Repositories;
using static RPG.Domain.Entities.Player;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IGameEventService, GameEventService>();
builder.Services.AddScoped<IPlayerService, PlayerService>();
builder.Services.AddTransient<IGuidFactory, GuidFactory>();
builder.Services.AddTransient<IPlayerFactory, PlayerFactory>();
builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();
builder.Services.AddDbContext<PlayerDbContext>();

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
