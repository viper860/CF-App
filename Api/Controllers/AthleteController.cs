using Api.Models;
using Models;
using System.Linq;
using System.Web.Mvc;

namespace InfiniteScrollingOnClient.Controllers
{
    public class AthleteController : Controller
    {
		private readonly IAthleteRepository athleteRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public AthleteController() : this(new AthleteRepository())
        {
        }

        public AthleteController(IAthleteRepository athleteRepository)
        {
			this.athleteRepository = athleteRepository;
        }

        //
        // GET: /Athlete/

        public ViewResult Index()
        {
            return View(athleteRepository.All);
        }

        //
        // GET: /Athlete/Details/5

        public ViewResult Details(int id)
        {
            return View(athleteRepository.Find(id));
        }

        //
        // GET: /Athlete/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Athlete/Create

        [HttpPost]
        public ActionResult Create(Athlete athlete)
        {
            if (ModelState.IsValid) {
                athleteRepository.InsertOrUpdate(athlete);
                athleteRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /Athlete/Edit/5
 
        public ActionResult Edit(int id)
        {
             return View(athleteRepository.Find(id));
        }

        //
        // POST: /Athlete/Edit/5

        [HttpPost]
        public ActionResult Edit(Athlete athlete)
        {
            if (ModelState.IsValid) {
                athleteRepository.InsertOrUpdate(athlete);
                athleteRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /Athlete/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(athleteRepository.Find(id));
        }

        //
        // POST: /Athlete/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            athleteRepository.Delete(id);
            athleteRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                athleteRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

