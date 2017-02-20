using System;
using System.Data.Entity;

// TODO: Move to a Movies.Domain class library.
namespace Movies.Web.Models
{
    public partial class MovieDbContext : DbContext
    {
        public MovieDbContext() : base("name=MovieDbContextDBConnection")
        {
        }

        public virtual DbSet<Actor> Actors { get; set; }
        public virtual DbSet<Cast> Casts { get; set; }
        public virtual DbSet<Certificate> Certificates { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Director> Directors { get; set; }
        public virtual DbSet<Film> Films { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<Studio> Studios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>()
                .Property(e => e.FullName)
                .IsUnicode(false);

            modelBuilder.Entity<Actor>()
                .Property(e => e.Gender)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Cast>()
                .Property(e => e.CharacterName)
                .IsUnicode(false);

            modelBuilder.Entity<Certificate>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Country>()
                .Property(e => e.CountryName)
                .IsUnicode(false);

            modelBuilder.Entity<Director>()
                .Property(e => e.FullName)
                .IsUnicode(false);

            modelBuilder.Entity<Director>()
                .Property(e => e.Gender)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Film>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Film>()
                .Property(e => e.Synopsis)
                .IsUnicode(false);

            modelBuilder.Entity<Genre>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Language>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Studio>()
                .Property(e => e.Name)
                .IsUnicode(false);
        }
    }
}
