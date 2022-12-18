// See https://aka.ms/new-console-template for more information
using Microsoft.Graphics.Canvas;
using SkiaSharp;
using Spectre.Console;

await AnsiConsole.Live(Text.Empty).StartAsync(async ctx =>
{
    var stream = new SKManagedStream(new FileStream("netflix.gif", FileMode.Open), true);
    var codec = SKCodec.Create(stream);
    var frames = codec.FrameInfo;

    var info = codec.Info;
    var bitmap = new SKBitmap(info);

    for(var frame = 0; frame < frames.Length; frame++)
    {
        var opts = new SKCodecOptions(frame);
        if (codec?.GetPixels(info, bitmap.GetPixels(), opts) != SKCodecResult.Success) continue;

        using var memStream = new MemoryStream();
        using var vStream = new SKManagedWStream(memStream);
        bitmap.Encode(vStream, SKEncodedImageFormat.Jpeg, 100);
        memStream.Position = 0;
        var data = memStream.ToArray();

        var canvasImage = new CanvasImage(data).MaxWidth(100);
        ct

    }
});




Console.WriteLine("Hello, World!");
