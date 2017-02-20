﻿using Movies.Web.Models;
using Movies.Web.Shared;

namespace Movies.Web.DTO
{
    public class DTOFactory : IDTOFactory
    {
        public FilmDTO Map(Film film)
        {
            //TODO: Replace with Automapper.
            return new FilmDTO
            {
                Id = film.Id,
                Title = film.Title,
                ReleaseYear = film?.ReleaseDate.Year(),
                Director = film?.Director?.FullName
            };
        }
    }
}