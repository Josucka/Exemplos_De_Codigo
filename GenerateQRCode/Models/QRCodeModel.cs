namespace GenerateQRCode.Models
{
    public class QRCodeModel
    {
        public int QRCodeType { get; set; }
        public string QRImageURL { get; set; }
        public string BookmarkTitle { get; set; }
        public string BookmarkURL { get; set; }
        public string ReceiverEmailAddress { get; set; }
        public string EmailSubjct { get; set; }
        public string EmailMessage { get; set; }
        public string SMSPhoneNumber { get; set; }
        public string SMSBody { get; set; }
        public string WebsiteURL { get; set; }
        public string WhatsAppNumber { get; set; }
        public string WhatsAppMenssage { get; set; }
        public string WIFIName { get; set; }
        public string WIFIPassword { get; set; }
    }
}
