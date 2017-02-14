using Movies.Web.Models;
using Movies.Web.Shared;

namespace Movies.Web.DTO
{
    public static class DtoFactories
    {
        public static FilmDto MapFilmtoFilmDto(Film film)
        {
            //TODO: Replace with Automapper.
            return new FilmDto
            {
                Id = film.Id,
                Title = film.Title,
                ReleaseYear = film?.ReleaseDate.Year(),
                Director = film?.Director?.FullName
            };
        }
    }
}