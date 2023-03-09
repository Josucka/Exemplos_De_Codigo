using Microsoft.AspNetCore.Mvc;
using GenerateQRCode.Models;
using QRCoder;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using static QRCoder.PayloadGenerator;

namespace GenerateQRCode.Controllers
{
    public class QRCodeController : Controller
    {
        public IActionResult Index()
        {
            QRCodeModel model = new QRCodeModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(QRCodeModel model)
        {
            Payload payload = null;
            switch(model.QRCodeType)
            {
                case 1:
                    payload = new Url(model.WebsiteURL);
                    break;
                case 2:
                    payload = new Bookmark(model.BookmarkURL, model.BookmarkURL);
                    break;
                case 3:
                    payload = new SMS(model.SMSPhoneNumber, model.SMSBody);
                    break;
                case 4:
                    payload = new WhatsAppMessage(model.WhatsAppNumber, model.WhatsAppMenssage);
                    break;
                case 5:
                    payload = new Mail(model.ReceiverEmailAddress, model.EmailSubjct, model.EmailMessage);
                    break;
                case 6:
                    payload = new WiFi(model.WIFIName, model.WIFIPassword, WiFi.Authentication.WPA);
                    break;
            }

            QRCodeGenerator qrCodeGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrCodeGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            var qrCodeImage = qrCode.GetGraphic(10);

            string base64String = Convert.ToBase64String(BitmapToByteArray(qrCodeImage));
            model.QRImageURL = "data:image/png;base64," + base64String;
            return View("Index", model);

        }

        private byte[] BitmapToByteArray(Bitmap qrCodeAsBitmap)
        {
            using(MemoryStream ms = new MemoryStream())
            {
                qrCodeAsBitmap.Save(ms, ImageFormat.Png);
                return ms.ToArray();    
            }
        }
    }
}
