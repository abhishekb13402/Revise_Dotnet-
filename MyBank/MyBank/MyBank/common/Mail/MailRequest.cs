namespace MyBank.common.Mail
{
    public class MailRequest
    {
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public List<IFormFile> Attachments { get; set; }
        public List<KeyValuePair<string, string>> PlaceHolders { get; set; }
    }
}
