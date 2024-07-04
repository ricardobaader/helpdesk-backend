using QRCoder;
using System.Drawing;

namespace Common.Utils
{
    public static class QRCodeGeneratorHelper
    {
        private static readonly string FrontendBaseUrl = Environment.GetEnvironmentVariable("FRONTEND_BASE_URL");

        private const int PixelsPerModule = 18;
        private static readonly Color DarkColor = Color.FromArgb(44, 136, 217);
        private static readonly Color LightColor = Color.White;
        private const int IconSizePercent = 30;
        private const int IconBorderWidth = 15;
        private const bool DrawQuietZones = false;
        private const int QrCodePositionY = 1050;

        private const int FixedQrCodeWidth = 600;
        private const int FixedQrCodeHeight = 600;

        public static byte[] GenerateQRCode(string name)
        {
            var qrCodeImage = GenerateQrCodeImage(name);
            var resizedQrCodeImage = ResizeImage(qrCodeImage, FixedQrCodeWidth, FixedQrCodeHeight);
            var baseImagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "template.png");
            var baseImage = LoadImage(baseImagePath);

            using var graphics = Graphics.FromImage(baseImage);

            DrawQrCodeOnBaseImage(graphics, resizedQrCodeImage, baseImage.Width);

            return ConvertImageToByteArray(baseImage);
        }

        private static Bitmap GenerateQrCodeImage(string name)
        {
            var qrGenerator = new QRCodeGenerator();
            var qrCodeData = qrGenerator.CreateQrCode($"{FrontendBaseUrl}/tickets/create/{name}", QRCodeGenerator.ECCLevel.H);
            var qrCode = new QRCode(qrCodeData);
            var iconPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "supportLogo.png");

            var icon = LoadImage(iconPath);

            return qrCode.GetGraphic(PixelsPerModule, DarkColor, LightColor, icon, IconSizePercent, IconBorderWidth, DrawQuietZones);
        }

        private static Bitmap LoadImage(string path)
        {
            using var stream = new FileStream(path, FileMode.Open, FileAccess.Read);
            return new Bitmap(stream);
        }

        private static void DrawQrCodeOnBaseImage(Graphics graphics, Bitmap qrCodeImage, int baseImageWidth)
        {
            int qrCodePositionX = (baseImageWidth - qrCodeImage.Width) / 2;
            graphics.DrawImage(qrCodeImage, qrCodePositionX, QrCodePositionY, qrCodeImage.Width, qrCodeImage.Height);
        }

        private static byte[] ConvertImageToByteArray(Image image)
        {
            using var ms = new MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms.ToArray();
        }

        private static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

                using (var wrapMode = new System.Drawing.Imaging.ImageAttributes())
                {
                    wrapMode.SetWrapMode(System.Drawing.Drawing2D.WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }
    }
}
