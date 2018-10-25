using System;

namespace InfoTrack.Models
{
  public class RankingResult
  {
    protected RankingResult()
    {
    }

    public int Rank { get; private set; }

    public static RankingResult CreateNew(int rank)
    {
      return new RankingResult
      {
        Rank = rank
      };
    }
  }
}
