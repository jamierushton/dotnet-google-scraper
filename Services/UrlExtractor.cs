using System;
using System.Text.RegularExpressions;

namespace InfoTrack.Services
{
  public static class UrlExtractor
  {
    private static Regex UrlRegex = new Regex(@"((\w+:\/\/)[-a-zA-Z0-9:@;?&=\/%\+\.\*!'\(\),\$_\{\}\^~\[\]`#|]+)", RegexOptions.Compiled);

    public static Uri ExtractFrom(string content)
    {
      Match match = UrlRegex.Match(content);
      if (match.Success)
        return new Uri(match.Value);

      return null;
    }
  }
}
