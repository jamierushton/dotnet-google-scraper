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
      try
      {
        string pageContent = _httpClient.GetStringAsync(endpoint).Result;
        return new HtmlContent(pageContent);
      }
      catch (Exception)
      {
        throw new Exception($"Unable to communite with server [{endpoint}].");
      }
    }
  }
}
