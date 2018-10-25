using System;

namespace InfoTrack.Services
{
  public interface IPostionFinder
  {
    int[] FindPositions(Uri domainAddressLookup, string keywords);
  }
}
