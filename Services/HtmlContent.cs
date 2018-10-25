namespace InfoTrack.Services
{
  public class HtmlContent
  {
    public HtmlContent(string html)
    {
      Html = html;
    }

    public string Html { get; private set; }
  }
}
