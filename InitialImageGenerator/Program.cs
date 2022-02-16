using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;

if (args.Length > 0)
{
    string name = args[0];
    string[] nameParts = name.Split(' ');
    string firstName = nameParts[0];
    string lastName = nameParts[1];

    var dataStream = new MemoryStream();
    dataStream.Position = 0;
    var image = new Bitmap(400, 400);
    for (int i = 0; i < image.Width; i++)
    {
        for (int j = 0; j < image.Height; j++)
        {
            image.SetPixel(i, j, Color.Black);
        }
    }

    var font = new Font("Tahoma", 150);


    Graphics graphic = Graphics.FromImage(image);
    graphic.SmoothingMode = SmoothingMode.AntiAlias;
    string initials = $"{firstName[0]}{lastName[0]}".ToUpper();
    var initialsSize = graphic.MeasureString(initials, font);
    var rectf = new RectangleF(200 - initialsSize.Width / 2, 200 - initialsSize.Height / 2, initialsSize.Width, initialsSize.Height);
    graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
    graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
    graphic.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
    graphic.DrawString(initials, font, Brushes.White, rectf);
    graphic.Flush();

    image.Save($"c:\\data\\initial_images\\{firstName}_{lastName}.png", ImageFormat.Png);
}
else
{
    Console.WriteLine("Please provide a name");
}
