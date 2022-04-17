using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FeedbackApplication.Services;
using FeedbackApplication.Dto;

namespace FeedbackApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;
        public  MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateMessageRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var (result, response) = await _messageService.CreateMessageAsync(request);
            if (!result.Success)
            {
                return BadRequest(result.ErrorMessage);
            }
            return Ok(response);
        }
    }
}
