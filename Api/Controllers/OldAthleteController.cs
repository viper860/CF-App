//using MvcInfiniteScrollGridDemo.Models;
using Api.Models;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Api.Controllers
{
    public class OldAthleteController : Controller
    {
        public const int RecordsPerPage = 20;
        private readonly IAthleteRepository athleteRepository;

        public OldAthleteController()
        {
            ViewBag.RecordsPerPage = RecordsPerPage;
        }

        public ActionResult Index()
        {
            return RedirectToAction("GetAthletes");
        }

        public ActionResult GetAthletes(int? pageNum)
        {
            pageNum = pageNum ?? 0;
            ViewBag.IsEndOfRecords = false;
            if (Request.IsAjaxRequest())
            {
                var athletes = GetRecordsForPage(pageNum.Value);
                ViewBag.IsEndOfRecords = (athletes.Any()) && ((pageNum.Value * RecordsPerPage) >= athletes.Last().Key);
                return PartialView("_AthleteRow", athletes);
            }
            else
            {
                LoadAllAthletesToSession();
                ViewBag.Athletes = GetRecordsForPage(pageNum.Value);
                return View("Index");
            }
        }

        public void LoadAllAthletesToSession()
        {
            var athleteRepo = new AthleteRepository();
            var athletes = athleteRepo.AllIncluding();
            int custIndex = 1;
            Session["Athletes"] = athletes.ToDictionary(x => custIndex++, x => x);
            ViewBag.TotalNumberAthletes = athletes.Count();
        }

        public Dictionary<int, Athlete> GetRecordsForPage(int pageNum)
        {
            Dictionary<int, Athlete> athletes = (Session["Athletes"] as Dictionary<int, Athlete>);

            int from = (pageNum * RecordsPerPage);
            int to = from + RecordsPerPage;

            return athletes
                .Where(x => x.Key > from && x.Key <= to)
                .OrderBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);
        }
    }
}