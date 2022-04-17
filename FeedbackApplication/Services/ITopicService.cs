using FeedbackApplication.Models;

namespace FeedbackApplication.Services
{
    public interface ITopicService
    {
        Task<IEnumerable<Topic>> GetTopicsAsync();
    }
}
