using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBotBase;

namespace BotAndWebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BotController : ControllerBase
    {
        private readonly BotBase _bot;
        public BotController(BotBase bot)
        {
            _bot = bot;
        }

        [HttpGet("setWebhook")]
        public async Task<string> SetWebHook()
        {
            var webhookUrl = "https://ba62-188-163-80-14.ngrok-free.app/bot";
            await _bot.Client.SetWebhookAsync(webhookUrl);

            var update = new Update
            {
                Id = 123456, // You can use a unique identifier
                Message = new Message
                {
                    MessageId = 1,
                    From = new User
                    {
                        Id = 914291734,
                        IsBot = false,
                        FirstName = "Test",
                        LastName = "User",
                        Username = "testuser",
                        LanguageCode = "en"
                    },
                    Chat = new Chat
                    {
                        Id = 914291734,
                        Type = ChatType.Private,
                        FirstName = "Test",
                        LastName = "User",
                        Username = "testuser"
                    },
                    Date = DateTime.UtcNow,
                    Text = "privet"
                }
            };

            await _bot.Client.HandleUpdateAsync(update);

            return $"Webhook set to {webhookUrl}";
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Update update)
        {
            if (update == null)
            {
                return BadRequest();
            }

            await _bot.Client.HandleUpdateAsync(update);

            Console.WriteLine("Сatch");

            return Ok();
        }
    }
}
