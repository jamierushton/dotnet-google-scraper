using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InfoTrack.Models;
using System;
using System.Linq;
using InfoTrack.Models.ViewModels;
using InfoTrack.Services;

namespace InfoTrack.Controllers
{
  public class HomeController : Controller
  {
    private readonly IPostionFinder _postionFinder;

    public HomeController(IPostionFinder postionFinder)
    {
      _postionFinder = postionFinder;
    }

    public IActionResult Index()
    {
      IndexViewModel viewModel = new IndexViewModel {
        Req = new RankingRequest {
          DomainAddress = "https://www.gov.uk",
          Keywords = "land registry search"
        }
      };

      return View(viewModel);
    }

    [HttpPost]
    public IActionResult Index(IndexViewModel viewModel)
    {
      if (!Uri.TryCreate(viewModel.Req.DomainAddress, UriKind.Absolute, out Uri domainAddress))
        ModelState.AddModelError(nameof(viewModel.Req.DomainAddress), "The given domain address is invalid");

      if (ModelState.IsValid)
      {
        int[] positions = _postionFinder.FindPositions(domainAddress, viewModel.Req.Keywords);
        viewModel.Results = positions.Select(RankingResult.CreateNew).ToArray();
      }

      return View(viewModel);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
