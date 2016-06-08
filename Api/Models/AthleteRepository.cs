using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace Api.Models
{
    public class AthleteRepository : IAthleteRepository
    {
        CsvContext context = new CsvContext();

        public IQueryable<Athlete> All
        {
            get { return context.Athletes; }
        }

        public IQueryable<Athlete> AllIncluding(params Expression<Func<Athlete, object>>[] includeProperties)
        {
            IQueryable<Athlete> query = context.Athletes;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Athlete Find(int id)
        {
            return context.Athletes.Find(id);
        }

        public void InsertOrUpdate(Athlete athlete)
        {
            if (athlete.CfId == default(int))
            {
                // New entity
                context.Athletes.Add(athlete);
            }
            else
            {
                // Existing entity
                context.Entry(athlete).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var athlete = context.Athletes.Find(id);
            context.Athletes.Remove(athlete);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IQueryable<Athlete> AthletePage(int pageNumber, int pageSize)
        {
            //var entity = db.Athletes.Include("LeaderboardThirteen")
            //     .OrderBy(c => c.CfId)
            //     .Skip((page-1) * pageSize)
            //     .Take(pageSize);
            //var entity = db.

            //return context.Athletes.OrderBy(f => f.CfId).Skip(pageSize * pageNumber).Take(pageSize);
            //return context.Athletes.Include("LeaderboardThirteen")
            //     .OrderBy(c => c.CfId)
            //     .Skip((pageNumber) * pageSize)
            //     .Take(pageSize);
            return context.Athletes.Include(a => a.LeaderboardThirteen)
                 .OrderBy(c => c.CfId)
                 .Skip((pageNumber) * pageSize)
                 .Take(pageSize);

        }
    }

    public interface IAthleteRepository : IDisposable
    {
        IQueryable<Athlete> All { get; }
        IQueryable<Athlete> AllIncluding(params Expression<Func<Athlete, object>>[] includeProperties);
        Athlete Find(int id);
        void InsertOrUpdate(Athlete athlete);
        void Delete(int id);
        void Save();
        IQueryable<Athlete> AthletePage(int pageNumber, int pageSize);

    }
}