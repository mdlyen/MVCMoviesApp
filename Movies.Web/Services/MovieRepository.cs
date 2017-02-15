﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Movies.Web.DTO;
using Movies.Web.Models;

namespace Movies.Web.Services
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieDbContext _dbContext = new MovieDbContext();
        private readonly DTOFactory _dtoFactory = new DTOFactory();

        public void Add(Film f)
        {
            _dbContext.Films.Add(f);
            _dbContext.SaveChanges();
        }

        public void Edit(Film f)
        {
            _dbContext.Entry(f).State = EntityState.Modified;
        }

        public Film FindById(int id)
        {
            var result = (from f in _dbContext.Films where f.Id == id select f).FirstOrDefault();
            return result;
        }

        public IEnumerable<FilmDTO> GetAllFilmDTOs()
        {
            //TODO: Replace with Automapper.
            var returnVar = new List<FilmDTO>();

            foreach (var film in _dbContext.Films.OrderBy(x=>x.Title))
            {
                returnVar.Add(_dtoFactory.Map(film));
            }

            return returnVar;
        }

        public void Remove(int id)
        {
            var f = _dbContext.Films.Find(id);

            if (f == null) return;

            _dbContext.Films.Remove(f);
            _dbContext.SaveChanges();
        }
    }
}