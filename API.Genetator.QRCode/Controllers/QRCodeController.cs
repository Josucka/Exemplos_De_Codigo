using Generate_QRCode.QRCodePast;
using Microsoft.AspNetCore.Mvc;

namespace API.Genetator.QRCode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QRCodeController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetByUrl([FromQuery] string url)
        {
            if (string.IsNullOrEmpty(url))
                url = "http://";

            var image = QrCodeGenerator.GenerateByteArray(url);
            return File(image, "image/jpeg");
        }
    }
}
