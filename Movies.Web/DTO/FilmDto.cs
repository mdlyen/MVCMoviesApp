using System.Dynamic;

namespace Movies.Web.DTO
{
    public class FilmDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ReleaseYear { get; set; }
        public string Director { get; set; }
    }
}
