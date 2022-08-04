using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using AthleteTracker.Models;
using System.Collections.Generic;
using System.Linq;

namespace AthleteTracker.Controllers
{
  public class SponsorsController : Controller
  {
    private readonly AthleteTrackerContext _db;

    public SponsorsController(AthleteTrackerContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Sponsor> model = _db.Sponsors.ToList();
      ViewBag.PageTitle = "View All Sponsors";
      return View(model);
    }

    public ActionResult Create()
    {
      ViewBag.PageTitle = "New Sponsor";
      return View();
    }

    [HttpPost]
    public ActionResult Create(Sponsor sponsor)
    {
      _db.Sponsors.Add(sponsor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisSponsor = _db.Sponsors
      .Include(sponsor => sponsor.JoinEntities)
      .ThenInclude(join => join.Athlete)
      .FirstOrDefault(sponsor => sponsor.SponsorId == id);
      return View(thisSponsor);
    }

    public ActionResult Edit (int id)
    {
      var thisSponsor = _db.Sponsors.FirstOrDefault(sponsor => sponsor.SponsorId == id);
      return View(thisSponsor);
    }

    [HttpPost]
    public ActionResult Edit(Sponsor sponsor)
    {
      _db.Entry(sponsor).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisSponsor = _db.Sponsors.FirstOrDefault(sponsor => sponsor.SponsorId == id);
      return View(thisSponsor);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisSponsor = _db.Sponsors.FirstOrDefault(sponsor => sponsor.SponsorId == id);
      _db.Sponsors.Remove(thisSponsor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}