namespace InfoTrack.Models.ViewModels
{
  public class IndexViewModel
  {
    public RankingRequest Req { get; set; }
    public RankingResult[] Results { get; set; }
    public bool HasResults => Results?.Length > 0;
  }
}