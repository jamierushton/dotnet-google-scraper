using System;

namespace InfoTrack.Services
{
  public static class UriExtensions
  {
    public static bool IsSameHost(this Uri a, Uri b)
    {
      if (a == null || b == null) return false;

      const string www = "www.";

      string firstHost = a.Host.Replace(www, string.Empty);
      string secondHost = b.Host.Replace(www, string.Empty);

      return string.Equals(firstHost, secondHost, StringComparison.OrdinalIgnoreCase);
    }
  }
}
