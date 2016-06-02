using Api.Models;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Controllers
{
    public class AthleteServiceController : ApiController
    {
        IAthleteRepository _repository;

        public AthleteServiceController(IAthleteRepository repo)
        {
            _repository = repo;
        }

        /// <summary>
        /// Delete this if you are using an IoC controller
        /// </summary>
        public AthleteServiceController()
        {
            _repository = new AthleteRepository();
        }

        [HttpGet]
        public IEnumerable<Athlete> GetAthletes(int id)
        {
            IEnumerable<Athlete> athletes = _repository.AthletePage(id, 5);
            return athletes;
        }
    }
}
