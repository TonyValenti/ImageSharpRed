// See https://aka.ms/new-console-template for more information
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Bmp;
using static System.Net.Mime.MediaTypeNames;

public class ImageImageSource : MigraDocCore.DocumentObjectModel.MigraDoc.DocumentObjectModel.Shapes.ImageSource.IImageSource {
    public SixLabors.ImageSharp.Image Image { get; }
    public ImageImageSource (SixLabors.ImageSharp.Image Input){
        this.Image = Input;
        this.Width = Input.Width;
        this.Height = Input.Height;
        this.Transparent = false;
        this.Name = $@"*{Guid.NewGuid()}";
    }
    
    public int Width { get; }
    public int Height { get; }
    public string Name { get; }
    public bool Transparent { get; }

    public void SaveAsJpeg(MemoryStream ms) {
        Image.SaveAsJpeg(ms);
    }

    public void SaveAsPdfBitmap(MemoryStream ms) {
        BmpEncoder bmp = new BmpEncoder { BitsPerPixel = BmpBitsPerPixel.Pixel32 };
        Image.Save(ms, bmp);
    }
}