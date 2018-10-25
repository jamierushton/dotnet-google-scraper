using System;
using System.Linq;
using System.Collections.Specialized;
using System.Web;

namespace InfoTrack.Services
{
  public class QueryUriBuilder
  {
    private static readonly Lazy<QueryUriBuilder> Lazy = new Lazy<QueryUriBuilder>(() => new QueryUriBuilder());

    protected QueryUriBuilder()
    {
    }

    public static QueryUriBuilder Instance => Lazy.Value;

    public Uri CreateNew(string uri, NameValueCollection pairs)
    {
      var array = (from key in pairs.AllKeys
                   from value in pairs.GetValues(key)
                   select $"{key}={HttpUtility.UrlEncode(value)}").ToArray();

      UriBuilder builder = new UriBuilder(uri);
      builder.Query = $"?{string.Join("&", array)}";

      return builder.Uri;
    }
  }
}
