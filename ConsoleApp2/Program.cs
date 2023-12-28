// See https://aka.ms/new-console-template for more information
using PdfSharpCore.Drawing;
var Doc = new PdfSharpCore.Pdf.PdfDocument();

Console.WriteLine($@" .NET {System.Environment.Version}");

var Files = new[] {
    $@".\000809D7.jpg",
};


foreach (var File in Files) {

    var Page = Doc.AddPage();
    {

        using var OriginalImage = SixLabors.ImageSharp.Image.Load(File);

        var ImageSource = new ImageImageSource(OriginalImage);

        using var Image = XImage.FromImageSource(ImageSource);

        Page.Height = Image.PointHeight;
        Page.Width = Image.PointWidth;

        using var G = XGraphics.FromPdfPage(Page);
        G.DrawImage(Image, 0, 0);
    }
}

Doc.Save($@"C:\Test.pdf");
