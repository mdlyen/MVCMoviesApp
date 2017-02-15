using System.Collections.Generic;
using System.Linq;
using Movies.Web.DTO;
using Movies.Web.Models;

namespace Movies.Web.Services
{
    public interface IMovieRepository
    {
        void Add(Film f);
        void Edit(Film f);
        Film FindById(int id);
        IEnumerable<FilmDTO> GetAllFilmDTOs();
        void Remove(int id);
    }
}