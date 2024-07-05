using QRCoder;
using System.Drawing;

namespace Common.Utils
{
    public static class QRCodeGeneratorHelper
    {
        private static readonly string FrontendBaseUrl = Environment.GetEnvironmentVariable("FRONTEND_BASE_URL");

        private const int FixedQrCodeSize = 700; // Tamanho fixo do QR Code
        private static readonly Color DarkColor = Color.FromArgb(44, 136, 217);
        private static readonly Color LightColor = Color.White;
        private const int IconSizePercent = 30;
        private const int IconBorderWidth = 15;
        private const bool DrawQuietZones = false;
        private const int QrCodePositionY = 1050;

        public static byte[] GenerateQRCode(string name)
        {
            var qrCodeImage = GenerateFixedSizeQrCodeImage(name);

            var baseImagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "template.png");
            var baseImage = LoadImage(baseImagePath);

            using var graphics = Graphics.FromImage(baseImage);

            DrawQrCodeOnBaseImage(graphics, qrCodeImage, baseImage.Width);

            return ConvertImageToByteArray(baseImage);
        }

        private static Bitmap GenerateFixedSizeQrCodeImage(string name)
        {
            var qrGenerator = new QRCodeGenerator();
            var qrCodeData = qrGenerator.CreateQrCode($"{FrontendBaseUrl}/tickets/create/{name}", QRCodeGenerator.ECCLevel.H);
            var qrCode = new QRCode(qrCodeData);
            var iconPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "supportLogo.png");

            var icon = LoadImage(iconPath);

            int pixelsPerModule = CalculatePixelsPerModule(qrCodeData.ModuleMatrix.Count, FixedQrCodeSize);

            return qrCode.GetGraphic(pixelsPerModule, DarkColor, LightColor, icon, IconSizePercent, IconBorderWidth, DrawQuietZones);
        }

        private static int CalculatePixelsPerModule(int moduleCount, int desiredSize)
        {
            return Math.Max(1, desiredSize / moduleCount);
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
    }
}
