namespace JacksonVeroneze.MailService.Api.Models
{
    public class MailRequest
    {
        public string From { get; set; }

        public string To { get; set; }

        public string Subject { get; set; }

        public string Text { get; set; }
    }
}
