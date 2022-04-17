using FeedbackApplication.Dto;

namespace FeedbackApplication.Services
{
    public interface IMessageService
    {
        Task<(ServiceResponse, MessageResponse?)> CreateMessageAsync(CreateMessageRequest request);
    }
}
