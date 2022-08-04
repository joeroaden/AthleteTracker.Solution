using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using AthleteTracker.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace AthleteTracker.Controllers
{
  public class AthletesController : Controller
  {
    private readonly AthleteTrackerContext _db;

    public AthletesController(AthleteTrackerContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Athletes.ToList());
    }

    public ActionResult Create()
    {
      ViewBag.SponsorId = new SelectList(_db.Sponsors, "SponsorId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Athlete athlete, int SponsorId)
    {
       _db.Athletes.Add(athlete);
       _db.SaveChanges();
       if (SponsorId != 0)
        {
          _db.SponsorAthlete.Add(new SponsorAthlete() { SponsorId = SponsorId, AthleteId = athlete.AthleteId });
          _db.SaveChanges();
        }
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisAthlete = _db.Athletes
          .Include(athlete => athlete.JoinEntities)
          .ThenInclude(join => join.Sponsor)
          .FirstOrDefault(athlete => athlete.AthleteId == id);
      return View(thisAthlete);
    }

    public ActionResult Edit(int id)
    {
      var thisAthlete = _db.Athletes.FirstOrDefault(athletes => athletes.AthleteId == id);
      ViewBag.SponsorId = new SelectList(_db.Sponsors, "SponsorId", "Name");
      return View(thisAthlete);
    }

     [HttpPost]
    public ActionResult Edit(Athlete athlete, int SponsorId)
    {
      if (SponsorId != 0)
      {
        _db.SponsorAthlete.Add(new SponsorAthlete() { SponsorId = SponsorId, AthleteId = athlete.AthleteId });
      }
      _db.Entry(athlete).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult AddSponsor(int id)
    {
      var thisAthlete = _db.Athletes.FirstOrDefault(athlete => athlete.AthleteId == id);
      ViewBag.SponsorId = new SelectList(_db.Sponsors, "SponsorId", "Name");
      return View(thisAthlete);
    }
    [HttpPost]
    public ActionResult AddSponsor(Athlete athlete, int SponsorId)
    {
      if (SponsorId != 0)
      {
        _db.SponsorAthlete.Add(new SponsorAthlete() { SponsorId = SponsorId, AthleteId = athlete.AthleteId });
        _db.SaveChanges();
      } 
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisAthlete = _db.Athletes.FirstOrDefault(athletes => athletes.AthleteId == id);
      return View(thisAthlete);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisAthlete = _db.Athletes.FirstOrDefault(athletes => athletes.AthleteId == id);
      _db.Athletes.Remove(thisAthlete);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
public ActionResult DeleteSponsor(int joinId)
{
    var joinEntry = _db.SponsorAthlete.FirstOrDefault(entry => entry.SponsorAthleteId == joinId);
    _db.SponsorAthlete.Remove(joinEntry);
    _db.SaveChanges();
    return RedirectToAction("Index");
} 
  }
}