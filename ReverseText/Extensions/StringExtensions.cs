using System.Text;

namespace ReverseText.Extensions
{
    public static class StringExtensions
    {
        public static string Reverse(this string text)
        {
            var sb = new StringBuilder();

            for (int i = text.Length - 1; i >= 0; i--)
            {
                sb.Append(text[i]);
            }

            return sb.ToString();
        }
    }
}