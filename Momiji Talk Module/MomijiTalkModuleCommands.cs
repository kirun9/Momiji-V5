using System.Threading.Tasks;
using Discord.Commands;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Dialogflow.V2;
using Grpc.Auth;

namespace Momiji.Bot.V5.Modules.MomijiTalkModule
{
	public class MomijiTalkModuleCommands : CommandBase
	{
		public MomijiTalkModule Module { get; set; }

		[Command("momiji")] //short for momiji
		[Alias("m", "8")]
		public async Task Talk([Remainder] string message)
		{
			var query = new QueryInput()
			{
				Text = new TextInput()
				{
					Text = message,
					LanguageCode = "en-EN",
				}
			};
			var sessionID = Context.User.Id + "." + Context.Guild.Id;
			var agent = "small-talk-fd100";
			var credits = GoogleCredential.FromJson(KeyReader.DIALOGFLOW_TOKEN);
			var channel = new Grpc.Core.Channel(SessionsClient.DefaultEndpoint.Host, credits.ToChannelCredentials());
			var client = SessionsClient.Create(channel);
			var callSettings = Google.Api.Gax.Grpc.CallSettings.FromHeader("charset", "UTF-8");
			var intent = client.DetectIntent(new SessionName(agent, sessionID), query, callSettings);
			if (intent.QueryResult.Intent.IsFallback)
			{
				var text = Module.ParseFallbackMessage(message);
				if (text == ((char)0x18).ToString()) return;
				await Context.Channel.SendMessageAsync(text);
			}
			else
			{
				await Context.Channel.SendMessageAsync(intent.QueryResult.FulfillmentText);
			}
			await channel.ShutdownAsync();
		}
	}
}
