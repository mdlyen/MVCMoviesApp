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
        private MovieDbContext db = new MovieDbContext();
        private IMovieRepository rep = new MovieRepository();

        // GET: api/Films
        public IEnumerable<FilmDto> GetFilms()
        {
            return rep.GetAllFilmDtos();
        }

        // GET: api/Films/5
        [ResponseType(typeof(FilmDto))]
        public IHttpActionResult GetFilm(int id)
        {
            Film film = db.Films.Find(id);
            if (film == null)
            {
                return NotFound();
            }

            return Ok(DtoFactories.MapFilmtoFilmDto(film));
        }

        // PUT: api/Films/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFilm(int id, Film film)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != film.Id)
            {
                return BadRequest();
            }

            db.Entry(film).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilmExists(id))
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

        // POST: api/Films
        [ResponseType(typeof(Film))]
        public IHttpActionResult PostFilm(Film film)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Films.Add(film);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (FilmExists(film.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = film.Id }, film);
        }

        // DELETE: api/Films/5
        [ResponseType(typeof(Film))]
        public IHttpActionResult DeleteFilm(int id)
        {
            Film film = db.Films.Find(id);
            if (film == null)
            {
                return NotFound();
            }

            db.Films.Remove(film);
            db.SaveChanges();

            return Ok(film);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FilmExists(int id)
        {
            return db.Films.Count(e => e.Id == id) > 0;
        }
    }
}