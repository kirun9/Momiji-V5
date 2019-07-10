using Discord.WebSocket;
using System;
using System.Threading.Tasks;

namespace Momiji.Bot.V5.Modules.Interface
{
	public interface IReciveReactionEvents
	{
		Task ReactionAdded(Discord.Cacheable<Discord.IUserMessage, UInt64> message, ISocketMessageChannel channel, SocketReaction reaction);
		Task ReactionRemoved(Discord.Cacheable<Discord.IUserMessage, UInt64> message, ISocketMessageChannel channel, SocketReaction reaction);
		Task ReactionsCleared(Discord.Cacheable<Discord.IUserMessage, UInt64> message, ISocketMessageChannel channel);
	}
}
