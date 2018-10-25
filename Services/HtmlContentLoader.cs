using System;
using System.Net.Http;

namespace InfoTrack.Services
{
  public static class HtmlContentLoader
  {
    private static HttpClient _httpClient;

    static HtmlContentLoader()
    {
      _httpClient = new HttpClient();
    }

    public static HtmlContent Load(Uri endpoint)
    {
      string pageContent = string.Empty;
      try
      {
        pageContent = _httpClient.GetStringAsync(endpoint).Result;
      }
      catch (Exception)
      {
        throw new Exception($"Unable to communite with server [{endpoint}].");
      }

      return new HtmlContent(pageContent);
    }
  }
}
