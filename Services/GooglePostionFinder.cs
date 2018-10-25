using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Specialized;
using System.Text.RegularExpressions;

namespace InfoTrack.Services
{
  public class GooglePostionFinder : IPostionFinder
  {
    public int MaximumSearchResults { get; set; } = 100;

    private static Regex PageEntryRegex = new Regex("<div class=\"g\">.*?</div>", RegexOptions.Compiled);

    private IEnumerable<HtmlContent> GetEntries(Uri endpoint)
    {
      var pageContent = HtmlContentLoader.Load(endpoint);
      var matches = PageEntryRegex.Matches(pageContent.Html);
      return matches.Select(match => new HtmlContent(match.Value));
    }

    public int[] FindPositions(Uri domainAddressLookup, string keywords)
    {
      Uri endpoint = BuildSearchUri(keywords);
      var entries = GetEntries(endpoint);

      IList<int> positions = new List<int>(capacity: MaximumSearchResults);
      int index = 1;
      foreach (HtmlContent entry in entries)
      {
        Uri entryUri = UrlExtractor.ExtractFrom(entry.Html);
        if (entryUri.IsSameHost(domainAddressLookup))
          positions.Add(index);

        index++;
      }

      return positions.ToArray();
    }

    private Uri BuildSearchUri(string keywords)
    {
      return QueryUriBuilder.Instance.CreateNew("https://www.google.co.uk/search", new NameValueCollection {
        {"num", MaximumSearchResults.ToString()},
        {"q", keywords}
      });
    }
  }
}
