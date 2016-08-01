using System.Text.RegularExpressions;
using Unidecode.NET;

namespace WebApplication.Services
{
    public interface ISeoFriendlyUrlStringConverter
    {
        string ToSeoFriendlyString(string input);
    }

    public class SeoFriendlyUrlStringConverter : ISeoFriendlyUrlStringConverter
    {
        private const int MaxStrLen = 45;
        private static readonly Regex InvalidCharsRegex = new Regex(@"[^a-z0-9\s-]", RegexOptions.Compiled);
        private static readonly Regex RemoveMultipleSpacesRegex = new Regex(@"\s+", RegexOptions.Compiled);
        private static readonly Regex SpaceRegex = new Regex(@"\s", RegexOptions.Compiled);
        
        public string ToSeoFriendlyString(string str)
        {
            str = str.Unidecode().ToLower();
            str = InvalidCharsRegex.Replace(str, "");
            str = RemoveMultipleSpacesRegex.Replace(str, " ").Trim();
            // cut and trim 
            str = str.Substring(0, str.Length <= MaxStrLen ? str.Length : MaxStrLen).Trim();
            str = SpaceRegex.Replace(str, "-"); // hyphens   
            return str;
        }
    }
}