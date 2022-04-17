namespace FeedbackApplication.Models
{
    public class Message
    {
        public int Id { get; set; }
        public int TopicId { get; set; }
        public Topic Topic { get; set; }
        public int ContactId { get; set; }
        public Contact Contact { get; set; }
        public string Text { get; set; }
    }
}
