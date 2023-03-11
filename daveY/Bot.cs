using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Interactivity;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using DSharpPlus.Interactivity.Extensions;
using DSharpPlus.EventArgs;
using daveY.Commands;

namespace daveY
{
    public class Bot
    {
        public DiscordClient Client { get; private set; }
        public InteractivityExtension Interactivity{ get; private set; }
        public CommandsNextExtension Commands { get; private set; }

        public async Task RunAsync()
        {
            var json = string.Empty;
            using (var fs = File.OpenRead("config.json"))
            using (var sr = new StreamReader(fs, new UTF8Encoding(false)))
                json = await sr.ReadToEndAsync();

            var configJson = JsonConvert.DeserializeObject<ConfigJSON>(json);
            var config = new DiscordConfiguration()
            {
                Intents=DiscordIntents.All,
                Token = configJson.Token,
                TokenType = TokenType.Bot,
                AutoReconnect = true,
            };

            Client = new DiscordClient(config);
            Client.UseInteractivity(new InteractivityConfiguration()
            {
                Timeout = TimeSpan.FromMinutes(2)
            });

            var commandConfig = new CommandsNextConfiguration()
            {
                StringPrefixes = new string[] { configJson.Prefix },
                EnableMentionPrefix = true,
                EnableDms = true,
                EnableDefaultHelp = false,
            };

            Commands = Client.UseCommandsNext(commandConfig);
            Commands.RegisterCommands<FunCommands>();
            Commands.RegisterCommands<Admin>();

            await Client.ConnectAsync();
            await Task.Delay(-1);

        }

        private Task OnClientReady(ReadyEventArgs e)
        {
            return Task.CompletedTask;
        }

    }
}
