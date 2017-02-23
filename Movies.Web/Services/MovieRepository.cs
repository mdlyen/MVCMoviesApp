using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Movies.Web.DTO;
using Movies.Web.Models;

namespace Movies.Web.Services
{
    public class MovieRepository : IMovieRepository
    {
        private readonly IDbSession _dbSession;
        private readonly IDTOFactory _dtoFactory;

        public MovieRepository(IDbSession dbSession, IDTOFactory dtoFactory)
        {
            _dbSession = dbSession;
            _dtoFactory = dtoFactory;
        }

        public IEnumerable<FilmDTO> GetAllFilms()
        {
            var returnVar = new List<FilmDTO>();
            var films = _dbSession.Set<Film>();

            foreach (var film in films)
            {
                returnVar.Add(_dtoFactory.Map(film));
            }

            return returnVar;
        }

        public FilmDTO GetFilmDTO(int filmid)
        {
            return _dtoFactory.Map(_dbSession.Set<Film>().Single(x => x.Id == filmid));
        }

        public IEnumerable<T> GetAll<T>() where T:class
        {
            return _dbSession.Set<T>();
        }
    }
}