using SoftBridge.Abstraction.IServicesContract.Chat;
using SoftBridge.Domain.Contracts.UnitOfWorkPattern;
using SoftBridge.Domain.Exceptions;
using SoftBridge.Domain.Exceptions.NotFoundModels;
using SoftBridge.Domain.Models.EnumHelper;
using SoftBridge.Domain.Models.OrderAggregates;
using SoftBridge.Domain.Models.Shared;
using SoftBridge.Domain.Models.User;
using SoftBridge.Services.Specification.ChatSpecifications.SaveMessageAsync;
using SoftBridge.Shared.Common.Dto.Chat;
using SoftBridge.Shared.Common.Pagination;
using SoftBridge.Shared.Common.Params;

namespace SoftBridge.Services.Services.Chat;

public class ChatService(IUnitOfWork unitOfWork) : IChatService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<MessageDto> SaveMessageAsync(string senderId, SendMessageDto sendMessageDto)
    {
        var serviceRequestRepo = _unitOfWork.GetRepository<ServiceRequest, Guid>();
        
        var requestId = sendMessageDto.RequestId;

        //to include client and provider in the same query to avoid multiple queries to check if the sender is either of them
        var serviceRequestSpec = new ServiceRequestByIdSpecification(requestId);

        var request = await serviceRequestRepo.GetByIdWithSpecAsync(serviceRequestSpec);

        if (request is null)
            throw new ServiceRequestNotFoundException("Service request not found");

        var isParticipant = request.Client.UserId == senderId 
                        || request.Provider.UserId == senderId;

        if(!isParticipant)
            throw new UnauthorizedExceptionCusotme("You are not part of this chat");

        var isAccepted = request.Status == RequestStatus.Accepted;

        if (!isAccepted)
            throw new BadRequestExceptionCustome("You can only chat on accepted requests");

        var message = new Message 
        {
            Id = Guid.NewGuid(), //not harmful
            RequestId = requestId,  
            SenderId = senderId,
            ReceiverId = request.Client.UserId == senderId
                ? request.Provider.UserId 
                : request.Client.UserId,
            Content = sendMessageDto.Content,
            SentAt = DateTime.UtcNow,
            IsRead = false
        };

        var messageRepo = _unitOfWork.GetRepository<Message, Guid>();

        await messageRepo.AddAsync(message);
        await _unitOfWork.SaveChangesAsync();

        var userRepo = _unitOfWork.GetRepository<ApplicationUser, string>();
        var sender = await userRepo.GetByIdAsync(senderId) 
                ?? throw new SenderNotFoundException("Sender not found");

        return new MessageDto 
        {
            Id = message.Id, 
            SenderId = message.SenderId,
            SenderName = sender is not null ? sender.FullName : "Unknown",
            RequestId = message.RequestId.Value,
            Content = message.Content,
            SentAt = message.SentAt,
            IsRead = message.IsRead
        };
    }

    public Task<PaginationResponse<MessageDto>> GetChatHistoryAsync(Guid requestId, BaseQueryParams queryParams)
    {
        throw new NotImplementedException();
    }

    public Task<bool> MarkMessagesAsReadAsync(Guid requestId, Guid receiverId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ChatInboxDto>> GetUserInboxAsync(Guid userId)
    {
        throw new NotImplementedException();
    }
    
}
