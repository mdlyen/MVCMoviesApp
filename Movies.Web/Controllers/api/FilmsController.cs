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
using Movies.Web.DTO;
using Movies.Web.Models;
using Movies.Web.Services;

namespace Movies.Web.Controllers.api
{
    public class FilmsController : ApiController
    {
        private readonly IMovieRepository _repository = new MovieRepository();
        private readonly DTOFactory _dtoFactory = new DTOFactory(); 

        // GET: api/v1/Films
        [Route("~/api/v1/Films")]
        public IEnumerable<FilmDTO> GetFilms()
        {
            return _repository.GetAllFilmDTOs();
        }

        // GET: api/v1/Films/5
        [ResponseType(typeof(FilmDTO))]
        [Route("~/api/v1/Films/{filmid:int}")]
        public IHttpActionResult GetFilm(int filmid)
        {
            var film = _repository.FindById(filmid);
            if (film == null)
            {
                return NotFound();
            }

            return Ok(_dtoFactory.Map(film));
        }
    }
}