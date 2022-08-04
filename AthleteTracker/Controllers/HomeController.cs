using Microsoft.AspNetCore.Mvc;

namespace AthleteTracker.Controllers
{
    public class HomeController : Controller
    {

      [HttpGet("/")]
      public ActionResult Index()
      {
        return View();
      }

    }
}