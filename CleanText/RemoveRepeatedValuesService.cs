using System.Linq;

namespace CleanText
{
    public sealed class RemoveRepeatedValuesService
    {
        /// <summary>
        /// Split a string and remove all repeated values
        /// </summary>
        /// <returns>The string without repeated values.</returns>
        /// <param name="text">A text.</param>
        /// <param name="separator">A separator.</param>
        public static string FromString(string text, char separator)
        {
            if(text == null)
            {
                return text;
            }
            var words = text.Split(separator);
            return words.Distinct().Aggregate((i,j) => $"{i}{separator}{j}");
        }
    }
}
