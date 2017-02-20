using Movies.Web.Models;

namespace Movies.Web.DTO
{
    public interface IDTOFactory
    {
        FilmDTO Map(Film film);
    }
}