using System.ComponentModel.DataAnnotations;

namespace Uichipedia.Model
{
    public class Article
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string? Category { get; set; }
        public string? Content { get; set; }   //The question mark after string indicates that the property is nullable

    }
}
