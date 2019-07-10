using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Momiji.Bot.V5.Modules.Interface
{
	public interface IReciveMessageEvents
	{
		Task MessageDeleted(Discord.Cacheable<Discord.IMessage, UInt64> message, ISocketMessageChannel channel);
		Task MessageRecived(SocketMessage message);
		Task MessagesBulkDeleted(IReadOnlyCollection<Discord.Cacheable<Discord.IMessage, UInt64>> messages, ISocketMessageChannel channel);
		Task MessageUpdated(Discord.Cacheable<Discord.IMessage, UInt64> oldMessage, SocketMessage message, ISocketMessageChannel channel);
	}
}
