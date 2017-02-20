using System.Collections.Generic;
using Movies.Web.DTO;

namespace Movies.Web.Services
{
    public interface IMovieRepository
    {
        IEnumerable<T> GetAll<T>() where T : class;
        IEnumerable<FilmDTO> GetAllFilms();
    }
}