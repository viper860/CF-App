using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Models;

namespace Api.Controllers
{
    public class AthletesController : ApiController
    {
        private CsvContext db = new CsvContext();

        // GET: api/Athletes
        //public IQueryable<Athlete> GetAthletes()
        //{
        //    return db.Athletes;
        //}

        // GET: api/Athletes
        public IQueryable<Athlete> GetAthletes(int page = 1, int pageSize = 10, string orderBy = "")
        {
            var totalCount = db.Athletes.Count();
            var totalPages = Math.Ceiling((double)totalCount / pageSize);
            var athleteQuery = db.Athletes;
            //var entity = db.Athletes.Include("LeaderboardThirteen")
            //     .OrderBy(c => c.CfId)
            //     .Skip((page-1) * pageSize)
            //     .Take(pageSize);
            var entity = db.Athletes.Include(a => a.LeaderboardThirteen)
                 .OrderBy(c => c.CfId)
                 .Skip((page - 1) * pageSize)
                 .Take(pageSize);

            return entity;
        }

        // GET: api/Athletes/5
        [ResponseType(typeof(Athlete))]
        public IHttpActionResult GetAthlete(int id)
        {
            Athlete athlete = db.Athletes.Find(id);
            if (athlete == null)
            {
                return NotFound();
            }

            return Ok(athlete);
        }

        // PUT: api/Athletes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAthlete(int id, Athlete athlete)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != athlete.AthleteId)
            {
                return BadRequest();
            }

            db.Entry(athlete).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AthleteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Athletes
        [ResponseType(typeof(Athlete))]
        public IHttpActionResult PostAthlete(Athlete athlete)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Athletes.Add(athlete);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = athlete.AthleteId }, athlete);
        }

        // DELETE: api/Athletes/5
        [ResponseType(typeof(Athlete))]
        public IHttpActionResult DeleteAthlete(int id)
        {
            Athlete athlete = db.Athletes.Find(id);
            if (athlete == null)
            {
                return NotFound();
            }

            db.Athletes.Remove(athlete);
            db.SaveChanges();

            return Ok(athlete);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AthleteExists(int id)
        {
            return db.Athletes.Count(e => e.AthleteId == id) > 0;
        }
    }
}