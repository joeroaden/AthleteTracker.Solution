using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using AthleteTracker.Models;
using System.Collections.Generic;
using System.Linq;

namespace AthleteTracker.Controllers
{
  public class SportsController : Controller
  {
    private readonly AthleteTrackerContext _db;

    public SportsController(AthleteTrackerContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Sport> model = _db.Sports.ToList();
      ViewBag.PageTitle = "View All Sports";
      return View(model);
    }

    public ActionResult Create()
    {
      ViewBag.PageTitle = "New Sport";
      return View();
    }

    [HttpPost]
    public ActionResult Create(Sport sport)
    {
      _db.Sports.Add(sport);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisSport = _db.Sports
      .Include(sport => sport.JoinEntities)
      .ThenInclude(join => join.Athlete)
      .FirstOrDefault(sport => sport.SportId == id);
      return View(thisSport);
    }

    public ActionResult Edit (int id)
    {
      var thisSport = _db.Sports.FirstOrDefault(sport => sport.SportId == id);
      return View(thisSport);
    }

    [HttpPost]
    public ActionResult Edit(Sport sport)
    {
      _db.Entry(sport).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisSport = _db.Sports.FirstOrDefault(sport => sport.SportId == id);
      return View(thisSport);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisSport = _db.Sports.FirstOrDefault(sport => sport.SportId == id);
      _db.Sports.Remove(thisSport);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}