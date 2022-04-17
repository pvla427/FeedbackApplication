using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FeedbackApplication.Models;
using FeedbackApplication.Services;

namespace FeedbackApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        private readonly ITopicService _topicService;
        public TopicController(ITopicService topicService) => _topicService = topicService;
        [HttpGet]
        public async Task<IEnumerable<Topic>> Get()
        {
            return await _topicService.GetTopicsAsync();
        }
    }
}
