namespace FeedbackApplication.Dto
{
    public class MessageResponse
    {
        public int Id { get; set; }
        public int TopicId { get; set; }
        public string TopicName { get; set; }
        public int ContactId { get; set; }
        public string ContactName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhoneNumber { get; set; }
        public string Text { get; set; }
    }
}
