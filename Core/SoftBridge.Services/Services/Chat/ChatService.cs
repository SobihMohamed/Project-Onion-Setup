using AutoMapper;
using SoftBridge.Abstraction.IServicesContract.Chat;
using SoftBridge.Domain.Contracts.UnitOfWorkPattern;
using SoftBridge.Domain.Exceptions;
using SoftBridge.Domain.Exceptions.NotFoundModels;
using SoftBridge.Domain.Models.EnumHelper;
using SoftBridge.Domain.Models.OrderAggregates;
using SoftBridge.Domain.Models.Shared;
using SoftBridge.Domain.Models.User;
using SoftBridge.Services.Specification.ChatSpecifications;
using SoftBridge.Shared.Common.Dto.Chat;
using SoftBridge.Shared.Common.Pagination;
using SoftBridge.Shared.Common.Params;

namespace SoftBridge.Services.Services.Chat;

public class ChatService(IUnitOfWork unitOfWork, IMapper mapper) : IChatService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;

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

        var userRepo = _unitOfWork.GetRepository<ApplicationUser, string>();
        var sender = await userRepo.GetByIdAsync(senderId) 
                ?? throw new SenderNotFoundException("Sender not found");

        await messageRepo.AddAsync(message);
        await _unitOfWork.SaveChangesAsync();
        
        //only for mapping the sender's full name
        message.Sender = sender;

        var messageDto = _mapper.Map<Message, MessageDto>(message);
        
        return messageDto;
    }

    public async Task<PaginationResponse<MessageDto>> GetChatHistoryAsync(string senderId, Guid requestId, BaseQueryParams queryParams)
    {
        var serviceRequestRepo = _unitOfWork.GetRepository<ServiceRequest, Guid>();
        var serviceRequestSpec = new ServiceRequestByIdSpecification(requestId);

        var request = await serviceRequestRepo.GetByIdWithSpecAsync(serviceRequestSpec);


        if (request is null)
            throw new ServiceRequestNotFoundException("Service request not found");

        var isParticipant = request.Client.UserId == senderId 
                        || request.Provider.UserId == senderId;
        
        if (!isParticipant)
            throw new UnauthorizedExceptionCusotme("You are not part of this chat");
        
        if (request.Status != RequestStatus.Accepted)
            throw new BadRequestExceptionCustome("You can only view chat history of accepted requests");


        var messageRepo = _unitOfWork.GetRepository<Message, Guid>();

        var messageSpec = new MessagesByRequestIdSpecification(requestId, queryParams); //gets list of messages paginated and ordered ascending by sentAt
        var messages = await messageRepo.GetAllWithSpecAsync(messageSpec);

        var messagesCountSpec = new MessagesCountByRequestIdSpecification(requestId); //gets total count of messages for the request
        var totalMessages = await messageRepo.GetCountAsync(messagesCountSpec); //for pagination metadata

        var messagesDto = _mapper.Map<List<MessageDto>>(messages);

        return new PaginationResponse<MessageDto>(queryParams.PageIndex, queryParams.PageSize, totalMessages, messagesDto);
    }

    public async Task MarkMessagesAsReadAsync(Guid requestId, string receiverId)
    {
        var serviceRequestRepo = _unitOfWork.GetRepository<ServiceRequest, Guid>();
        var serviceRequestSpec = new ServiceRequestByIdSpecification(requestId);

        var request = await serviceRequestRepo.GetByIdWithSpecAsync(serviceRequestSpec);

        if (request is null)
            throw new ServiceRequestNotFoundException("Service request not found");
        
        var isParticipant = request.Client.UserId == receiverId
                        || request.Provider.UserId == receiverId;
        
        if (!isParticipant)
            throw new UnauthorizedExceptionCusotme("You are not part of this chat");

        var messageRepo = _unitOfWork.GetRepository<Message, Guid>();
        var unreadMessagesSpec = new UnreadMessagesSpec(requestId, receiverId);

        //need to refactor this later , discuss with the team.
        var unreadMessages = await messageRepo.GetAllWithSpecAsync(unreadMessagesSpec);
        foreach (var message in unreadMessages)
            message.IsRead = true;      

        await _unitOfWork.SaveChangesAsync();  
    }

    public async Task<IEnumerable<ChatInboxDto>> GetUserInboxAsync(string userId)
    {
        var serviceRequestRepo = _unitOfWork.GetRepository<ServiceRequest, Guid>();
        var serviceRequestWithChatsSpec = new ChatInboxSpec(userId);

        var serviceRequests = await serviceRequestRepo.GetAllWithSpecAsync(serviceRequestWithChatsSpec);


        var inbox = serviceRequests.Select(sr => 
        {
            var lastMessage = sr.Messages.OrderByDescending(m => m.SentAt).FirstOrDefault();

            var unreadMessagesCount = sr.Messages.Count(m => m.ReceiverId == userId && !m.IsRead);

            return new ChatInboxDto
            {
                RequestId = sr.Id,
                RequestTitle = sr.Service.Title,
                LastMessageContent = lastMessage?.Content ?? string.Empty,
                LastMessageSentAt = lastMessage?.SentAt ?? DateTime.MinValue,
                UnreadCount = unreadMessagesCount
            };
        });

        return inbox.ToList();
    }
    
}
