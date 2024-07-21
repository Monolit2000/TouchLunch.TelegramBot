using BotAndWebApplication.BotStuff;
using BotAndWebApplication.BotStuff.Tasks;
using BotAndWebApplication.Controllers;
using TelegramBotBase;
using TelegramBotBase.Builder;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHostedService<BotBackgroundTask>();

builder.Services.AddSingleton<BotBase>(provider =>
{
    return BotBaseBuilder.Create()
        .WithAPIKey("6998376856:AAE1SCknGBCTxI3jR3bVksJ5tQcB_BDp5Xs")
        .DefaultMessageLoop()
        .WithStartForm<StartForm>()
        .NoProxy(true)
        .DefaultCommands()
        .NoSerialization()
        .UseEnglish()
        .UseThreadPool()
        .Build();
});

builder.Services.AddControllers();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

