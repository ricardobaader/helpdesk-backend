using Microsoft.AspNetCore.Http;

namespace Common.Utils.Extensions
{
    public static class FormFileExtensions
    {
        public static async Task<byte[]> ConvertToByteArray(this IFormFile value)
        {
            if (value is null)
                return Array.Empty<byte>();

            using MemoryStream ms = new();
            await value.CopyToAsync(ms);
            var imageBytes = ms.ToArray();

            return imageBytes;
        }
    }
}
