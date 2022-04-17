using FeedbackApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace FeedbackApplication.Services
{
    public class TopicService : ITopicService
    {
        private readonly ApplicationDbContext _db;
        public TopicService(ApplicationDbContext db) => _db = db;
        public async Task<IEnumerable<Topic>> GetTopicsAsync() => await _db.Topics.ToListAsync();
    }
}
