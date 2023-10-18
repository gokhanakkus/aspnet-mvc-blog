using System.Text.RegularExpressions;

namespace App.Web.Mvc.Utils
{
    public class UrlFriend
    {
        public static string SeoName(string name)
        {
            return Regex.Replace(name.ToLower().Replace(@"'", String.Empty), @"[^\w]+", "-");
        }
    }
}
