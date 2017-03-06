using System;
using System.Data.Entity;
using Movies.Web.Models;

// TODO: Move to a Movies.Domain class library.
namespace Movies.Web.Tests.Fakes
{
    public sealed class FakeMovieDbContext : DbContext
    {
        public FakeMovieDbContext()
        {
        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Cast> Casts { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Studio> Studios { get; set; }
    }
}
