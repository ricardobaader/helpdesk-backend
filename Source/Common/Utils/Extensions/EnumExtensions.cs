using System.ComponentModel;

namespace Common.Utils.Extensions
{
    public static class EnumExtension
    {
        public static string GetDescription<T>(this T value) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
                return null;

            var description = value.ToString();

            var fieldInfo = value.GetType().GetField(value.ToString() ?? string.Empty);
            if (fieldInfo == null)
                return description;

            var attributes = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), true);
            if (attributes.Length > 0)
                description = ((DescriptionAttribute)attributes[0]).Description;

            return description;
        }
    }
}
