using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using Movies.Web.DTO;
using Movies.Web.Models;
using Movies.Web.Services;

namespace Movies.Web.Controllers.api
{
    public class FilmsController : ApiController
    {
        private readonly IDTOFactory _dtoFactory;
        private readonly IMovieRepository _movieRepository;

        public FilmsController()
        {
            // Manual dependency injection for now...
            _dtoFactory = new DTOFactory();
            _movieRepository = new MovieRepository(new EntityDbSession(new MovieDbContext()), _dtoFactory);
        }

        // GET: api/v1/Films/5
        [ResponseType(typeof(FilmDTO))]
        [Route("~/api/v1/Films/{filmid:int}")]
        public IHttpActionResult GetFilm(int filmid)
        {
            var film = _movieRepository.GetFilmDTO(filmid);
            if (film == null)
            {
                return NotFound();
            }

            return Ok(film);
        }        
        
        // GET: api/v1/Films
        [Route("~/api/v1/Films")]
        public IEnumerable<FilmDTO> GetFilms()
        {
            return _movieRepository.GetAllFilms();
        }
    }
}