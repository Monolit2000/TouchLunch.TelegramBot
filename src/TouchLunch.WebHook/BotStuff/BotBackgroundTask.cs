using Telegram.Bot.Types;
using TelegramBotBase;
using TelegramBotBase.Builder;

namespace BotAndWebApplication.BotStuff.Tasks
{
    public class BotBackgroundTask : IHostedService
    {
        public ILogger<BotBackgroundTask>? Logger { get; }

        public BotBase BotBaseInstance { get; private set; }

        BotBackgroundTask(BotBase botBase)
        {
            BotBaseInstance = botBase;

            //BotBaseInstance = BotBaseBuilder.Create()
            //                    .WithAPIKey("6998376856:AAE1SCknGBCTxI3jR3bVksJ5tQcB_BDp5Xs" ??
            //                        throw new Exception("API_KEY is not set"))
            //                    .DefaultMessageLoop()
            //                    .WithStartForm<StartForm>()
            //                    .NoProxy()
            //                    .DefaultCommands()
            //                    .NoSerialization()
            //                    .UseEnglish()
            //                    .UseThreadPool()
            //                    .Build();
        }

        public BotBackgroundTask(ILogger<BotBackgroundTask> logger, BotBase botBase) : this(botBase)
        {
            Logger = logger;
        }





        public async Task StartAsync(CancellationToken cancellationToken)
        {

            if (BotBaseInstance == null)
                return;

            Logger?.LogInformation("Bot is starting.");

            //await BotBaseInstance.UploadBotCommands();

            await BotBaseInstance.Start();


            Logger?.LogInformation("Bot has been started.");
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            if (BotBaseInstance == null)
                return;

            Logger?.LogInformation("Bot will shut down.");

            //Let all users know that the bot will shut down.

            await BotBaseInstance.SentToAll("Bot will shut down now.");

            await BotBaseInstance.Stop();

            Logger?.LogInformation("Bot has shutted down.");
        }
    }
}
