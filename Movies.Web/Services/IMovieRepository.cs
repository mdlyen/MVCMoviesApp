using System.Collections.Generic;
using Movies.Web.DTO;
using Movies.Web.Models;

namespace Movies.Web.Services
{
    public interface IMovieRepository
    {
        void Add(Film f);
        void Edit(Film f);
        Film FindById(int id);
        IList<FilmDto> GetAllFilmDtos();
        void Remove(int id);
    }
}