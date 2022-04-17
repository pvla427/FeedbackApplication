using FeedbackApplication.Models;
using FeedbackApplication.Dto;
using Microsoft.EntityFrameworkCore;

namespace FeedbackApplication.Services
{
    public class MessageService : IMessageService
    {
        private readonly ApplicationDbContext _db;
        public MessageService(ApplicationDbContext db) => _db = db;
        public async Task<(ServiceResponse, MessageResponse?)> CreateMessageAsync(CreateMessageRequest request)
        {
            var topic = await _db.Topics.FirstOrDefaultAsync(topic => topic.Id == request.Topic);
            if (topic == null)
            {
                return (new ServiceResponse { 
                    Success = false, 
                    ErrorMessage = "Topic doesn't exist" 
                }, null);
            }
            var contact = await _db.Contacts.FirstOrDefaultAsync(contact => contact.Email == request.Email && contact.PhoneNumber == request.PhoneNumber);
            if (contact == null)
            {
                contact = new Contact
                {
                    Name = request.Name,
                    Email = request.Email,
                    PhoneNumber = request.PhoneNumber
                };
                _db.Contacts.Add(contact);
                await _db.SaveChangesAsync();
            }
            var message = new Message
            {
                TopicId = request.Topic,
                ContactId = contact.Id,
                Text = request.Message
            };
            _db.Messages.Add(message);
            await _db.SaveChangesAsync();
            return (new ServiceResponse
            {
                Success = true,
                ErrorMessage = String.Empty
            },
            new MessageResponse
            {
                Id = message.Id,
                TopicId = message.TopicId,
                TopicName = message.Topic.Name,
                ContactId = message.ContactId,
                ContactName = message.Contact.Name,
                ContactEmail = message.Contact.Email,
                ContactPhoneNumber = message.Contact.PhoneNumber,
                Text = message.Text,
            });
        }
    }
}
