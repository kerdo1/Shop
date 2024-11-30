namespace ShopTARge23.Models
{
    public class EmailModel
    {
        public string To { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public List<IFormFile> Attachments {get; set;}

    }
}
