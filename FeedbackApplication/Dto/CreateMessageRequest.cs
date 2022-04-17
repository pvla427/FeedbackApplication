using System.ComponentModel.DataAnnotations;

namespace FeedbackApplication.Dto
{
    public class CreateMessageRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        [Required]
        public int Topic { get; set; }
        [Required]
        public string Message { get; set; }
    }
}
