using System;
using System.Collections.Generic;
using System.Text;

namespace SoftBridge.Abstraction.IServicesContract.Chat
{
    // This interface defines the contract for the private messaging system.
    // It works alongside SignalR Hubs to save messages to the database and retrieve chat histories.
    public interface IChatService
    {
        //Task<MessageDto> SaveMessageAsync(SendMessageDto sendMessageDto);
        //Task<Pagination<MessageDto>> GetChatHistoryAsync(Guid requestId, BaseQueryParams queryParams); // Chat is scoped to a specific request
        //Task<bool> MarkMessagesAsReadAsync(Guid requestId, Guid receiverId);
        //Task<IEnumerable<ChatInboxDto>> GetUserInboxAsync(Guid userId); // Get list of active chats
    }
}