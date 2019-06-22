using Discord;
using Discord.Rest;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Momiji.Bot.V5.Modules.MyDiscord
{
	public class DiscordSocketClient
	{
		private Discord.WebSocket.DiscordSocketClient _DiscordSocketClient { get; set; }
		
		//
		// Summary:
		//     Gets the login state of the client.
		public LoginState LoginState { get => _DiscordSocketClient.LoginState; }
		//
		// Summary:
		//     Gets the logged-in user.
		public ISelfUser CurrentUser { get => _DiscordSocketClient.CurrentUser; }
		public TokenType TokenType { get => _DiscordSocketClient.TokenType; }
		public IReadOnlyCollection<RestVoiceRegion> VoiceRegions { get => _DiscordSocketClient.VoiceRegions; }
		//
		// Summary:
		//     Gets a collection of group channels opened in this session.
		//
		// Returns:
		//     An collection of group channels that have been opened in this session.
		//
		// Remarks:
		//     This method returns a collection of currently opened group channels. This method
		//     will not return previously opened group channels outside of the current session!
		//     If you have just started the client, this may return an empty collection.
		public IReadOnlyCollection<SocketGroupChannel> GroupChannels { get => _DiscordSocketClient.GroupChannels; }
		//
		// Summary:
		//     Gets a collection of direct message channels opened in this session.
		//
		// Returns:
		//     An collection of DM channels that have been opened in this session.
		//
		// Remarks:
		//     This method returns a collection of currently opened direct message channels.
		//     This method will not return previously opened DM channels outside of the current
		//     session! If you have just started the client, this may return an empty collection.
		public IReadOnlyCollection<SocketDMChannel> DMChannels { get => _DiscordSocketClient.DMChannels; }
		//
		public IReadOnlyCollection<ISocketPrivateChannel> PrivateChannels { get => _DiscordSocketClient.PrivateChannels; }
		//
		public IReadOnlyCollection<SocketGuild> Guilds { get => _DiscordSocketClient.Guilds; }
		//
		public IActivity Activity { get => _DiscordSocketClient.Activity; }
		//
		public UserStatus Status { get => _DiscordSocketClient.Status; }
		//
		public Int32 Latency { get => _DiscordSocketClient.Latency; }
		//
		// Summary:
		//     Gets the current connection state of this client.
		public ConnectionState ConnectionState { get => _DiscordSocketClient.ConnectionState; }
		//
		// Summary:
		//     Gets the shard of of this client.
		public Int32 ShardId { get => _DiscordSocketClient.ShardId; }
		//
		// Summary:
		//     Provides access to a REST-only client with a shared state from this client.
		public DiscordSocketRestClient Rest { get => _DiscordSocketClient.Rest; }

		public DiscordSocketClient(Discord.WebSocket.DiscordSocketClient client)
		{
			_DiscordSocketClient = client;
		}


		public Task DownloadUsersAsync(IEnumerable<IGuild> guilds) => _DiscordSocketClient.DownloadUsersAsync(guilds);
		public Task<RestApplication> GetApplicationInfoAsync(RequestOptions options = null) => _DiscordSocketClient.GetApplicationInfoAsync(options);
		public SocketChannel GetChannel(UInt64 id) => _DiscordSocketClient.GetChannel(id);
		public SocketGuild GetGuild(UInt64 id) => _DiscordSocketClient.GetGuild(id);
		public SocketUser GetUser(String username, String discriminator) => _DiscordSocketClient.GetUser(username, discriminator);
		public SocketUser GetUser(UInt64 id) => _DiscordSocketClient.GetUser(id);
		public RestVoiceRegion GetVoiceRegion(String id) => _DiscordSocketClient.GetVoiceRegion(id);
		public Task<Int32> GetRecommendedShardCountAsync(RequestOptions options = null) => _DiscordSocketClient.GetRecommendedShardCountAsync(options);
	}
}
