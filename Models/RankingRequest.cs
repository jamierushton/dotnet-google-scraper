using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InfoTrack.Models
{
  public class RankingRequest
  {
    [DisplayName("Domain address"), Required, Url]
    public string DomainAddress { get; set; }

    [Required]
    public string Keywords { get; set; }
  }
}
